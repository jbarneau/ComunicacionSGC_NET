using ComunicacionSGC_NET.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Funtions
{
    class FuncionesComunicar
    {
        private FuncionesSQL meBase = new FuncionesSQL();

        #region "IMPLEMENTADAS"
        public string comunicar_GEO(string Poli, string ntrabajo)
        {
            string log = "";
            GeoExgadet migeo = meBase.RetornarGeo(Poli);
            if (migeo.existe)
            {
                if (migeo.Origen != "NT" && migeo.ncodRetorno == "-")
                {
                    try
                    {
                        log = "\n***Geroreferencia***\n";
                        GeoSGC geoNat = new GeoSGC();
                        geoNat.latitud = migeo.latitud.Replace(",", ".");
                        geoNat.longitud = migeo.longitud.Replace(",", ".");
                        geoNat.nroTrabajo = int.Parse(ntrabajo);
                        geoNat.identPolExpMac = "P";
                        geoNat.polExpMAc = int.Parse(Poli);
                        geoNat.origenGeoref = 10;
                        ComunicarGEO comunicargeo = new ComunicarGEO();
                        log = log + "Coordenasas enviadas: " + JsonConvert.SerializeObject(geoNat, Formatting.None).ToString();
                        string errorgeo = comunicargeo.comunicarGEO_SGC(geoNat);
                        log = log + "\n Resultado:" + errorgeo;
                        ErrorGEO geoerror = JsonConvert.DeserializeObject<ErrorGEO>(errorgeo);
                        meBase.ComunicarGeo(Poli, geoerror.ncodRetorno, geoerror.nreInput);
                        log = log + "\n******* FIN GEO *****";

                    }
                    catch (Exception ex) { log = "***** ERROR EN CONTRUIR GEO *****\n" + "Error:" + ex.Message + "\n***** ERROR EN CONTRUIR GEO *****"; }

                }
            }
            else { log = "**** NO SE PUEDE RECUPPERAR OBJETO GEO ****"; }
            return log;

        }

        public string Com28(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            //Controlada 26-03-2021
            string log = "Poliza " + Poli + " Tipo trabajo:28 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT28 o28 = meBase.GENERAR_OT_28(Poli, Fe, ntrabajo, feCliente);
            if (o28 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o28, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT28_SGC(o28);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                                                if (secomunico == 1)
                        {
                            log = log + comunicar_GEO(Poli, nRgnf);
                        }
                        meBase.ComunicarBD_C901(Poli.ToString(), ntrabajo, Fe, "28", secomunico, respuesta.nreInput);
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com33_34(string Poli, DateTime Fe, string ntrabajo, string OT, DateTime feCliente, String nRgnf)
        {
            //CONTROLADO 26-03-2021
            string log = "Poliza " + Poli + " Tipo trabajo:" + OT.ToString() + " - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT33_34 o33_34 = meBase.GENERAR_OT_33_34(Poli, Fe, ntrabajo, OT, feCliente);
            if (o33_34 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o33_34, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT33_34_SGC(o33_34, OT);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC_33_34 respuesta = JsonConvert.DeserializeObject<ErrorSGC_33_34>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        if (secomunico == 1)
                        {
                            log = log + comunicar_GEO(Poli, nRgnf);
                            try
                            {
                                string nuevaOt;
                                try
                                {
                                    nuevaOt = respuesta.generoOt;
                                }
                                catch
                                {
                                    nuevaOt = "0";
                                }
                                if (nuevaOt != "0" && nuevaOt != null)
                                {
                                    log = log + "\n Genero nueva OT: " + nuevaOt.ToString();
                                    string nuevoNgnf = DateTime.Now.ToString("HHmmss");
                                    DateTime nuevaFE = DateTime.Today;
                                    log = log + "\n\n" + meBase.Generar_C900(Poli, ntrabajo, Fe, OT, nuevaOt.ToString(), nuevoNgnf, nuevaFE, "M");
                                    log = log + "\n" + meBase.Generar_C901(Poli, ntrabajo, Fe, OT, nuevaOt.ToString(), nuevoNgnf, nuevaFE);
                                    log = log + "\n" + meBase.Generar_Z017(Poli, ntrabajo, Fe, OT, nuevaOt.ToString(),  nuevaFE);
                                }
                            }
                            catch (Exception ex)
                            {
                                log = log + "\n Error al leer la tarea comunicada";
                            }
                        }
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, OT, secomunico, respuesta.nreInput);
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com37(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:37 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT37_39_40 o37 = meBase.GENERAR_OT_37(Poli, Fe, ntrabajo, feCliente);
            if (o37 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o37, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT37_SGC(o37);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "37", secomunico, respuesta.nreInput);
                        if (secomunico == 1)
                            log = log + "\n" + comunicar_GEO(Poli, nRgnf);
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
       public string Com39(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:39 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT37_39_40 o39 = meBase.GENERAR_OT_39(Poli, Fe, ntrabajo, feCliente);
            if (o39 != null)
            {
                try
                {
                    ComunicarSGC funcion = new ComunicarSGC();
                    log = log + "Envio: " + JsonConvert.SerializeObject(o39, Formatting.None).ToString();
                    string respuesta1 = funcion.comunicarOT39_SGC(o39);
                    log = log + "\n Respuesta: " + respuesta1;
                    if (respuesta1 != "" && respuesta1 != "--")
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "39", secomunico, respuesta.nreInput);
                        if (secomunico == 1)
                            log = log + "\n" + comunicar_GEO(Poli, nRgnf);
                    }
                }
                catch (Exception ex)
                {
                    log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com40(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:40 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT37_39_40 o40 = meBase.GENERAR_OT_40(Poli, Fe, ntrabajo, feCliente);
            if (o40 != null)
            {
                try
                {
                    ComunicarSGC funcion = new ComunicarSGC();
                    log = log + "Envio: " + JsonConvert.SerializeObject(o40, Formatting.None).ToString();
                    string respuesta1 = funcion.comunicarOT40_SGC(o40);
                    log = log + "\n Respuesta: " + respuesta1;
                    if (respuesta1 != "" && respuesta1 != "--")
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "40", secomunico, respuesta.nreInput);
                        if (secomunico == 1)
                        {
                            log = log + comunicar_GEO(Poli, nRgnf);
                        }
                        }
                }
                catch (Exception ex)
                {
                    log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com42_43(string Poli, DateTime Fe, string ntrabajo, string OT, DateTime feCliente, String nRgnf)
        {
            //CONTROLADO 26-03-2021
            string log = "Poliza " + Poli + " Tipo trabajo:" + OT.ToString() + " - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT42_43 o42_43 = meBase.GENERAR_OT_42_43(Poli, Fe, ntrabajo, feCliente, OT);
            if (o42_43 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o42_43, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT42_43_SGC(o42_43, OT);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, OT, secomunico, respuesta.nreInput);
                        if (secomunico == 1)
                        {
                            log = log + comunicar_GEO(Poli, nRgnf);
                            try {
                                if (o42_43.resultadoMac == 1) { log = log+"\r\n CAMBIO DE ESTADO ALMACENES \r\n" + meBase.ComunicarMedidorAlmacen(Convert.ToDecimal(o42_43.numeroColoMac), Poli);
                                }
                            
                            } catch(Exception ex) {
                                log = log + "Error: " + ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com45(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:45 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT45 o45 = meBase.GENERAR_OT_45(Poli, Fe, ntrabajo, feCliente);
            if (o45 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o45, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT45_SGC(o45);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "45", secomunico, respuesta.nreInput);
                       
                        if (secomunico == 1)
                            log = log + comunicar_GEO(Poli, nRgnf);
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com46(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:46 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT46 o46 = meBase.GENERAR_OT_46(Poli, Fe, ntrabajo, feCliente);
            if (o46 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = "Envio: " + JsonConvert.SerializeObject(o46, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT46_SGC(o46);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        if (secomunico == 1)
                        {
                            log = log + comunicar_GEO(Poli, nRgnf);
                        }
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "46", secomunico, respuesta.nreInput);
                    }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }

                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com49(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:49 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT49 o49 = meBase.GENERAR_OT_49(Poli, Fe, ntrabajo, feCliente);
            if (o49 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o49, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT49_SGC(o49);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "" && respuesta1 != "--")
                {
                    try
                    {
                        ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                        int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                        meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "49", secomunico, respuesta.nreInput);
                        if (secomunico == 1)
                                                    log = log + comunicar_GEO(Poli, nRgnf);
                                            }
                    catch (Exception ex)
                    {
                        log = log + "ERROR AL SERIALIZAR RESPUESTA " + ex.Message;
                    }
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        #endregion

        #region "SUSPENDIDAS"
        public string Com11(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:11 - Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            OT11_17_47_54 o11 = meBase.GENERAR_OT_11(Poli, Fe, ntrabajo, feCliente);
            if (o11 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Enviado: " + JsonConvert.SerializeObject(o11, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT11_SGC(o11);
                log = log + " Respuesta: " + respuesta1;
                if (respuesta1 != "")
                {
                    ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                    int secomunico = 1;
                    if (respuesta.nreInput != "")
                        secomunico = 0;
                    if (secomunico == 1) log = log + "\n Geo:" + comunicar_GEO(Poli, nRgnf);
                    meBase.ComunicarBD_C904(Poli.ToString(), ntrabajo, Fe, "11", secomunico, respuesta.nreInput);
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com17(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "";
            OT11_17_47_54 o17 = meBase.GENERAR_OT_17(Poli, Fe, ntrabajo, feCliente);
            if (o17 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o17, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT17_SGC(o17);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "")
                {
                    ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                    int secomunico = 1;
                    if (respuesta.nreInput != "")
                        secomunico = 0;
                    if (secomunico == 1) log = log + "\n Geo:" + comunicar_GEO(Poli, nRgnf);
                    meBase.ComunicarBD_C904(Poli.ToString(), ntrabajo, Fe, "17", secomunico, respuesta.nreInput);
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }
        public string Com54(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:54\n";
            OT11_17_47_54 o54 = meBase.GENERAR_OT_54(Poli, Fe, ntrabajo, feCliente);
            if (o54 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = log + "Envio: " + JsonConvert.SerializeObject(o54, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT54_SGC(o54);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "")
                {
                    ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                    int secomunico = 1;
                    if (respuesta.nreInput != "")
                        secomunico = 0;
                    if (secomunico == 1) log = log + "\n Geo:" + comunicar_GEO(Poli, nRgnf);
                    meBase.ComunicarBD_C904(Poli.ToString(), ntrabajo, Fe, "54", secomunico, respuesta.nreInput);
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }

        public string Com47(string Poli, DateTime Fe, string ntrabajo, DateTime feCliente, String nRgnf)
        {
            string log = "Poliza " + Poli + " Tipo trabajo:47\n";
            OT11_17_47_54 o47 = meBase.GENERAR_OT_47(Poli, Fe, ntrabajo, feCliente);
            if (o47 != null)
            {
                ComunicarSGC funcion = new ComunicarSGC();
                log = "Envio: " + JsonConvert.SerializeObject(o47, Formatting.None).ToString();
                string respuesta1 = funcion.comunicarOT47_SGC(o47);
                log = log + "\n Respuesta: " + respuesta1;
                if (respuesta1 != "")
                {
                    ErrorSGC respuesta = JsonConvert.DeserializeObject<ErrorSGC>(respuesta1);
                    int secomunico = respuesta.nreInput.Length != 0 ? 0 : 1;
                    meBase.ComunicarBD_C901(Poli, ntrabajo, Fe, "47", secomunico, respuesta.nreInput);
                    if (secomunico == 1) log = log + "\n Geo:" + comunicar_GEO(Poli, nRgnf);
                }
            }
            else
            {
                log = log + "ERROR AL CONSTRUIR OBJETO";
            }
            return log;
        }


        #endregion

        






    }
}
