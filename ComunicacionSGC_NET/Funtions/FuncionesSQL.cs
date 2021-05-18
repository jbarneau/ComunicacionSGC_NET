using ComunicacionSGC_NET.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComunicacionSGC_NET.Funtions
{
    class FuncionesSQL
    {
        CadenaConexion cadena = new CadenaConexion();

        #region "Comunicacion de Base de Datos"

        public string Generar_C900(string nparte, string ngnf, DateTime fe, string ot, string nuevaOT, string nuevoNgnf, DateTime nuevaFE, string origen)
        {
            string respuesta = "SE GENERO LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                string consulta = "INSERT INTO C900_TAREAS (CCONT900, TIPO_TRAB900, CMOTIVO900, NGNF900, FE_EMISION900, NPARTE900, ORGTRAB900, FUGA_AVISO900, POLIZA900, APE_NOM900, TELEFONO900, CPART900, CLOCA900, NOMCALLE900, NPUERTA900, ESC900, PISO900, PUERTA900, CP900, ENTRE900, SITUACION900, CONS900, CIIUU900, TA900, T_CLIENTE900, SIT_DEUDA900, NMEDIDOR900, CAPACIDAD900, MARCA900, TIPOMED900, ESFMED900, LECTURA900, TOTDEUDA900, PRESION900, COMPLEMENTO900, COMPLEMENTO2_900, COMPLEMENTO3_900, FREALIZADO900, FASIGNADO900, FCOMU900, COPERARIO900, AUSENTE900, PRIORIDAD900, NRECORRIDO900, FVTO900, MATRI900) SELECT CCONT900,'" + nuevaOT + "' AS tiponuevo, '" + nuevaOT + "' AS motivonuevo,'" + nuevoNgnf + "' AS nuegongnf,cast('" + nuevaFE + "' as DATE) AS nuevafe, NPARTE900, '" + origen + "' as ORIGEN, FUGA_AVISO900, POLIZA900, APE_NOM900, TELEFONO900, CPART900, CLOCA900, NOMCALLE900, NPUERTA900, ESC900, PISO900, PUERTA900, CP900, ENTRE900, SITUACION900, CONS900, CIIUU900, TA900, T_CLIENTE900, SIT_DEUDA900, NMEDIDOR900, CAPACIDAD900, MARCA900, TIPOMED900, ESFMED900, LECTURA900, TOTDEUDA900, PRESION900, COMPLEMENTO900, COMPLEMENTO2_900, COMPLEMENTO3_900, FREALIZADO900, FASIGNADO900, FCOMU900, COPERARIO900, AUSENTE900, PRIORIDAD900, NRECORRIDO900, FVTO900, MATRI900 FROM C900_TAREAS AS C900_TAREAS_1 WHERE (CCONT900 = N'001') AND (NPARTE900 ='" + nparte + "') AND (TIPO_TRAB900 ='" + ot + "') AND (NGNF900 = '" + ngnf + "') AND (FE_EMISION900 = '" + fe + "')";

                cnn.Open();
                SqlCommand adt = new SqlCommand(consulta, cnn);

                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                respuesta = "ERROR AL GENERAR LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString() + " | ERROR:" + ex.Message + "|C900";
            }
            finally
            {
                cnn.Close();
            }
            return respuesta;
        }
        public string Generar_Z017(string nparte, string ngnf, DateTime fe, string ot, string nuevaOT, DateTime nuevaFE)
        {
            string respuesta = "SE GENERO LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                string consulta = "INSERT INTO Z017_TEMP_TAREA_PEND_GENREAR (CCONT017, FE_EMISION017, NPARTE017, COPERARIO017, TIPO_TRAB017) SELECT CCONT900,'" + nuevaFE + "' AS newfe, NPARTE900, COPERARIO900,'" + nuevaOT + "' as nueot FROM C900_TAREAS WHERE(CCONT900 ='001') AND(TIPO_TRAB900 ='" + ot + "') AND(FE_EMISION900 ='" + fe + "') AND(NPARTE900 ='" + nparte + "') AND (NGNF900='" + ngnf + "')";

                cnn.Open();
                SqlCommand adt = new SqlCommand(consulta, cnn);

                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                respuesta = "ERROR AL GENERAR LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString() + " | ERROR:" + ex.Message + "|Z017";
            }
            finally
            {
                cnn.Close();
            }
            return respuesta;
        }
        public string Generar_C901(string nparte, string ngnf, DateTime fe, string ot, string nuevaOT, string nuevoNgnf, DateTime nuevaFE)
        {
            string respuesta = "SE COMUNICO LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("INSERT INTO C901_UTILIZACION (CCONT901, TIPO_TRAB901, FE_EMISION901, PARTE901, NGNF901, CMOTIVO901, CTAREA901, FREALIZADO901, COPERARIO901, OBSERV901, TCIERRE901, REALIZO901, FIRMO901, CONFORME901, ACLARACION901, DNI901, MEDRETIRADO901, ESTADORET901, MEDCOLOCA901, ESTADOCOLA901, USERASIG901, FASIG901, FCOMUNICO901, RASIG901, VMED901, VPAPEL901, FOTO901, TPAPEL901, RSCANER901, USRSCAN901, FPAPEL901, CHABIT901, INTESC901, DOMINC901, MEDDIS901, MEDENC901, MARENC901, CAPENC901, ESFENC901, DIRCORRE901, ENTRECORR901, LOCACORR901, USGC901) SELECT CCONT901, @V1 AS Expr1, @V2 AS Expr2, PARTE901, @V3 AS Expr3, @V4 AS Expr4, CTAREA901, FREALIZADO901, COPERARIO901, OBSERV901, TCIERRE901, REALIZO901, FIRMO901, CONFORME901, ACLARACION901, DNI901, MEDRETIRADO901, ESTADORET901, MEDCOLOCA901, ESTADOCOLA901, USERASIG901, FASIG901, FCOMUNICO901, RASIG901, VMED901, VPAPEL901, FOTO901, TPAPEL901, RSCANER901, USRSCAN901, FPAPEL901, CHABIT901, INTESC901, DOMINC901, MEDDIS901, MEDENC901, MARENC901, CAPENC901, ESFENC901, DIRCORRE901, ENTRECORR901, LOCACORR901, USGC901 FROM C901_UTILIZACION AS C901_UTILIZACION_1 WHERE (CCONT901 = N'001') AND (PARTE901 = @D1) AND (TIPO_TRAB901 = @D2) AND (FE_EMISION901 = @D3) AND (NGNF901 = @D4)", cnn);
                adt.Parameters.AddWithValue("V1", nuevaOT);
                adt.Parameters.AddWithValue("V2", nuevaFE);
                adt.Parameters.AddWithValue("V3", nuevoNgnf);
                adt.Parameters.AddWithValue("V4", nuevaOT);
                adt.Parameters.AddWithValue("D1", nparte);
                adt.Parameters.AddWithValue("D2", ot);
                adt.Parameters.AddWithValue("D3", fe);
                adt.Parameters.AddWithValue("D4", ngnf);
                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                respuesta = "ERROR AL COMUNICAR LA OT " + nuevaOT.ToString() + " PARA LA POLIZA: " + nparte.ToString() + " | ERROR:" + ex.Message + "|C900";

            }
            finally
            {
                cnn.Close();
            }
            return respuesta;
        }
        public void ComunicarBD_C901(string nparte, string ngnf, DateTime fe, string ot, int secomunica, string errorSGC)
        {
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("UPDATE C901_UTILIZACION SET ESTCOMU901=@D1, FCOMU901=@D2, ERRORCOMU901=@D3 WHERE PARTE901=@E1 AND NGNF901=@E2 AND FE_EMISION901=@E3 AND TIPO_TRAB901=@E4", cnn);
                adt.Parameters.AddWithValue("D1", secomunica);
                adt.Parameters.AddWithValue("D2", DateTime.Now);
                adt.Parameters.AddWithValue("D3", errorSGC);
                adt.Parameters.AddWithValue("E1", nparte);
                adt.Parameters.AddWithValue("E2", ngnf);
                adt.Parameters.AddWithValue("E3", fe);
                adt.Parameters.AddWithValue("E4", ot);
                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message + "\n ComunicarBD_C901");
            }
            finally
            {
                cnn.Close();
            }
        }
        public void ComunicarBD_C904(string nparte, string ngnf, DateTime fe, string ot, int secomunica, string errorSGC)
        {
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("UPDATE C904_ACOMETIDA SET ESTCOMU904=@D1, FCOMU904=@D2, ERRORCOMU904=@D3 WHERE NPARTE904=@E1 AND NGNF904=@E2 AND FE_EMISION904=@E3 AND TIPO_TRAB904=@E4", cnn);
                adt.Parameters.AddWithValue("D1", secomunica);
                adt.Parameters.AddWithValue("D2", DateTime.Now);
                adt.Parameters.AddWithValue("D3", errorSGC);
                adt.Parameters.AddWithValue("E1", nparte);
                adt.Parameters.AddWithValue("E2", ngnf);
                adt.Parameters.AddWithValue("E3", fe);
                adt.Parameters.AddWithValue("E4", ot);
                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message + "\n ComunicarBD_C904");
            }
            finally
            {
                cnn.Close();
            }
        }
        public void ComunicarGeo(string nparte, string ncodRetorno, string nreInput)
        {
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("UPDATE Z012_CORDENADAS SET nreInput=@D1, ncodRetorno=@D2 WHERE POLIZA012=@E1", cnn);
                adt.Parameters.AddWithValue("D1", nreInput);
                adt.Parameters.AddWithValue("D2", ncodRetorno);
                adt.Parameters.AddWithValue("E1", nparte);
                adt.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message + "\n ComunicarGeo");
            }
            finally
            {
                cnn.Close();
            }
        }
        public string ComunicarMedidorAlmacen(decimal NSERIE, string POLIZA)
        {
            string resultado = "";
            SqlConnection con1 = new SqlConnection(cadena.Almacen);
            con1.Open();
            try
            {
                // creo el comando para pasarle los parametros
                SqlCommand comando1 = new SqlCommand("Update T_MEDI_102 set POLIZA_102=@D1, F_POLIZA_102=@D2, USER_102=@D3, ESTADO_102 = 5 WHERE NSERIE_102=@E1", con1);
                // creo el lector de parametros
                comando1.Parameters.Add(new SqlParameter("D1", POLIZA));
                comando1.Parameters.Add(new SqlParameter("D2", DateTime.Now));
                comando1.Parameters.Add(new SqlParameter("D3", "0"));
                comando1.Parameters.Add(new SqlParameter("E1", NSERIE));
                int i = comando1.ExecuteNonQuery();
                if (i == 1) { resultado = "Se cambio el estado del medidor " + NSERIE + " utilizado en poliza " + POLIZA; } else { resultado = "No se cambio el estado del medidor " + NSERIE + " utilizado en poliza " + POLIZA; }
            }
            catch (Exception ex)
            {
                resultado = "Ocurrio un error al actualizar el medidor " + NSERIE + "\r\n Error: \r\n" + ex.Message + "\r\n";

            }
            finally
            {
                con1.Close();
            }
            return resultado;
        }
        #endregion
        #region "Generador de ot Acometida"
        //acometida
        public OT11_17_47_54 GENERAR_OT_11(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT11_17_47_54 OT11C = new OT11_17_47_54();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB904,NPARTE904, REALIZO904, FREALIZADO904, OBS904, FIRMO904, CONFORME904 FROM C904_ACOMETIDA WHERE (NPARTE904 = @D1) AND (TIPO_TRAB904='11') AND (FE_EMISION904=@D2)AND (NGNF904=@D3) ORDER BY NPARTE904", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT11C.polExpMac = int.Parse(poliza);
                    OT11C.identPolExpMac = "P";
                    OT11C.nusuarioMac = "ARX0103";
                    OT11C.agenteMac = 0;
                    OT11C.contrataMac = 768;
                    OT11C.observNuevaMac = ObsGas(dt.GetString(4).ToUpper());
                    OT11C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                    OT11C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                    OT11C.estadoRetiMac = 0;
                    OT11C.anexosMac = obtenerAnexos(poliza, "11", ngnf, (DateTime)dt.GetDateTime(3), fe);
                    if (dt.GetString(2) == "R")
                    {
                        OT11C.resultadoMac = 1;
                        OT11C.firmoCteMac = "NO";
                        OT11C.confCteMac = "NO";
                        //if (dt.GetString(5)==null ) {
                        //} else {
                        //  OT11C.firmoCteMac = dt.GetString(5);
                        //  OT11C.confCteMac = dt.GetString(6);
                        //}   
                    }
                    else
                    {
                        OT11C.resultadoMac = 2;
                        OT11C.firmoCteMac = "NO";
                        OT11C.confCteMac = "NO";
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT11C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT11C.colorMac.Add(".".PadLeft(15, ' '));
                            OT11C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    for (int cv = OT11C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT11C.cdVivMac.Add("00");
                        OT11C.colorMac.Add("".PadLeft(15, ' '));
                        OT11C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT11C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT11C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT11C = null;
                MessageBox.Show(ex.Message + "\n OT11");
            }
            finally
            {
                CNN.Close();
            }

            return OT11C;
        }
        public OT11_17_47_54 GENERAR_OT_17(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT11_17_47_54 OT17C = new OT11_17_47_54();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB904,NPARTE904, REALIZO904, FREALIZADO904, OBS904, FIRMO904, CONFORME904 FROM C904_ACOMETIDA WHERE (NPARTE904 = @D1) AND (TIPO_TRAB904='17') AND (FE_EMISION904=@D2)AND (NGNF904=@D3) ORDER BY NPARTE904", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT17C.polExpMac = int.Parse(poliza);
                    OT17C.agenteMac = 0;
                    OT17C.nusuarioMac = "ARX0103";
                    OT17C.identPolExpMac = "P";
                    OT17C.contrataMac = 768;
                    OT17C.observNuevaMac = ObsGas(dt.GetString(4).ToUpper());
                    OT17C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                    OT17C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                    OT17C.estadoRetiMac = 0;
                    OT17C.anexosMac = obtenerAnexos(poliza, "11", ngnf, (DateTime)dt.GetDateTime(3), fe);
                    if (dt.GetString(2) == "R")
                    {
                        OT17C.resultadoMac = 1;
                        //if (dt.GetValue(5) != null)
                        //{
                        //    OT17C.firmoCteMac = dt.GetString(5);
                        //    OT17C.confCteMac = dt.GetString(6);
                        //}
                        //else
                        //{
                        OT17C.firmoCteMac = "NO";
                        OT17C.confCteMac = "NO";
                        //}
                    }
                    else
                    {
                        OT17C.resultadoMac = 2;
                        OT17C.firmoCteMac = "NO";
                        OT17C.confCteMac = "NO";
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT17C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT17C.colorMac.Add(".".PadLeft(15, ' '));
                            OT17C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    for (int cv = OT17C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT17C.cdVivMac.Add("00");
                        OT17C.colorMac.Add("".PadLeft(15, ' '));
                        OT17C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT17C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT17C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT17C = null;
                MessageBox.Show(ex.Message + "\n OT11");
            }
            finally
            {
                CNN.Close();
            }
            return OT17C;
        }
        public OT11_17_47_54 GENERAR_OT_54(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT11_17_47_54 OT54C = new OT11_17_47_54();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB904,NPARTE904, REALIZO904, FREALIZADO904, OBS904, FIRMO904, CONFORME904 FROM C904_ACOMETIDA WHERE (NPARTE904 = @D1) AND (TIPO_TRAB904='54') AND (FE_EMISION904=@D2)AND (NGNF904=@D3) ORDER BY NPARTE904", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT54C.polExpMac = int.Parse(poliza);
                    OT54C.identPolExpMac = "P";
                    OT54C.nusuarioMac = "ARX0103";
                    OT54C.contrataMac = 768;
                    OT54C.agenteMac = 0;
                    OT54C.observNuevaMac = ObsGas(dt.GetString(4).ToUpper());
                    OT54C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                    OT54C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));


                    OT54C.estadoRetiMac = 0;
                    if (dt.GetString(2) == "R")
                    {
                        OT54C.resultadoMac = 1;





                        OT54C.firmoCteMac = dt.GetString(5);
                        OT54C.confCteMac = dt.GetString(6);





                    }
                    else
                    {
                        OT54C.resultadoMac = 2;
                        OT54C.firmoCteMac = "NO";
                        OT54C.confCteMac = "NO";
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT54C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT54C.colorMac.Add(".".PadLeft(15, ' '));
                            OT54C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }



                    OT54C.anexosMac = obtenerAnexos(poliza, "11", ngnf, (DateTime)dt.GetDateTime(3), fe);
                    for (int cv = OT54C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT54C.cdVivMac.Add("00");
                        OT54C.colorMac.Add("".PadLeft(15, ' '));
                        OT54C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT54C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT54C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT54C = null;
                MessageBox.Show(ex.Message + "\n OT11");
            }
            finally
            {
                CNN.Close();
            }

            return OT54C;
        }

        #endregion
        #region "Generador de ot Utilizacion"
        public OT28 GENERAR_OT_28(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            //modificado 13-11-2020 trae usuario de SGC
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            //DataTable dt = new DataTable();
            SqlDataReader dt;
            OT28 OT28C = new OT28();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT C901_UTILIZACION.REALIZO901, C901_UTILIZACION.FREALIZADO901, C901_UTILIZACION.OBSERV901, C901_UTILIZACION.ESTADORET901, C901_UTILIZACION.FIRMO901, C901_UTILIZACION.CTAREA901,  C901_UTILIZACION.MEDCOLOCA901, C901_UTILIZACION.CHABIT901, C901_UTILIZACION.INTESC901, C901_UTILIZACION.DOMINC901, C901_UTILIZACION.MEDDIS901, M002_OPERARIO.USRSGC002, C901_UTILIZACION.CONFORME901,C901_UTILIZACION.USGC901 FROM C901_UTILIZACION INNER JOIN M002_OPERARIO ON C901_UTILIZACION.COPERARIO901 = M002_OPERARIO.NDNI002 WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901 = '28') AND (C901_UTILIZACION.FE_EMISION901 = @D2) AND (C901_UTILIZACION.NGNF901 = @D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT28C.polExpMac = int.Parse(poliza);
                    OT28C.identPolExpMac = "P";
                    OT28C.contrataMac = 768;
                    // OT28C.nusuarioMac = lector.GetString(13);
                    OT28C.nusuarioMac = "EXT0002";
                    if (dt.GetString(0) == "R")
                    {
                        OT28C.resultadoMac = obtenerAprobadoRechazado(dt.GetString(5), "001");
                    }
                    else
                    {
                        OT28C.resultadoMac = 13;
                    }
                    if (dt.GetString(6) != "")
                    {
                        OT28C.instaloMedMac = "SI";
                    }
                    else
                    {
                        OT28C.instaloMedMac = "NO";
                    }
                    try
                    {
                        OT28C.firmoCteMac = dt.GetString(4);
                    }
                    catch
                    {
                        OT28C.firmoCteMac = "NO";
                    }
                    try
                    {
                        OT28C.confCteMac = dt.GetString(12);
                    }
                    catch
                    {
                        OT28C.confCteMac = "SI";
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {

                        OT28C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT28C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));

                        }
                        else
                        {
                            OT28C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT28C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT28C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT28C.observNuevaMac = ObsGas(obs);
                    OT28C.agenteMac = float.Parse(dt.GetValue(11).ToString());
                    // traio los codigos anexos
                    OT28C.anexosMac = obtenerAnexos(poliza.ToString(), "28", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    // artegactos
                    OT28C.codRechaMac = obtenerCodRechazo(poliza.ToString(), "28", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    List<artefacto> artefatos = obtenerArtefactos(poliza.ToString(), "28", ngnf, fe);
                    foreach (artefacto item in artefatos)
                    {
                        OT28C.tipoArtefMac.Add(item.codigo);
                        OT28C.usoArtefMac.Add(item.tipo);
                        OT28C.ubicArtefMac.Add(item.ubicacion);
                        OT28C.cantidadMac.Add(item.cant);
                        OT28C.clausuroArtefMac.Add(item.clausurado);
                    }
                    // completo los campos
                    for (int art = OT28C.codRechaMac.Count; art <= 9; art++)
                    {
                        OT28C.codRechaMac.Add("    ");
                    }
                    for (int art = OT28C.tipoArtefMac.Count; art <= 9; art++)
                    {
                        OT28C.tipoArtefMac.Add("  ");
                        OT28C.ubicArtefMac.Add("  ");
                        OT28C.cantidadMac.Add(0);
                        OT28C.usoArtefMac.Add(" ");
                        OT28C.clausuroArtefMac.Add("  ");
                    }
                    for (int art = OT28C.anexosMac.Count; art <= 9; art++)
                    {
                        OT28C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT28C = null;
                // MessageBox.Show(ex.Message + "\n OT28");
            }
            finally
            {
                CNN.Close();
            }
            return OT28C;
        }
        public OT33_34 GENERAR_OT_33_34(string poliza, DateTime fe, string ngnf, string ot, DateTime feCliente)
        {
            //modificado 13-11-2020 - tare usuario sgc
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT33_34 OT33_34C = new OT33_34();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT C901_UTILIZACION.REALIZO901, C901_UTILIZACION.FREALIZADO901, C901_UTILIZACION.OBSERV901, C901_UTILIZACION.FIRMO901, C901_UTILIZACION.MEDRETIRADO901, C901_UTILIZACION.ESTADORET901,  C901_UTILIZACION.MEDCOLOCA901, C901_UTILIZACION.ESTADOCOLA901, M002_OPERARIO.USRSGC002, C901_UTILIZACION.CTAREA901,C901_UTILIZACION.CONFORME901, C901_UTILIZACION.USGC901 FROM C901_UTILIZACION INNER JOIN M002_OPERARIO ON C901_UTILIZACION.COPERARIO901 = M002_OPERARIO.NDNI002 WHERE (C901_UTILIZACION.PARTE901 = @D0) AND (C901_UTILIZACION.TIPO_TRAB901 = @D1) AND (C901_UTILIZACION.FE_EMISION901 = @D2) AND (C901_UTILIZACION.NGNF901 = @D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D0", poliza);
                ADT.Parameters.AddWithValue("D1", ot);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT33_34C.polExpMac = int.Parse(poliza);
                    OT33_34C.agenteMac = dt.GetInt32(8);
                    OT33_34C.nusuarioMac = "EXT0002";
                    //OT33_34C.nusuarioMac = lector.GetString(11);
                    OT33_34C.contrataMac = 768;
                    OT33_34C.identPolExpMac = "P";
                    //COMPLETO FIRMO
                    try
                    {
                        OT33_34C.firmoCteMac = dt.GetString(3);
                    }
                    catch
                    {
                        OT33_34C.firmoCteMac = "NO";
                    }
                    //COMPLETO CONFORME
                    try
                    {
                        OT33_34C.confCteMac = dt.GetString(10);
                    }
                    catch
                    {
                        OT33_34C.confCteMac = "SI";
                    }
                    if (dt.GetString(0) == "R")
                    {
                        OT33_34C.resultadoMac = obtenerAprobadoRechazado(dt.GetString(9), "001");
                        //SI ESTA REACHAZA PASO VACIO
                        if (OT33_34C.resultadoMac == 14)
                        {
                            OT33_34C.recolocoCambioMac = " ";
                        }
                        else
                        {
                            //PREGUNTO SI SE CAMBIO MEDIDOR
                            if (dt.GetString(6) != "")
                            {
                                OT33_34C.recolocoCambioMac = "S";
                            }
                            else
                            {
                                OT33_34C.recolocoCambioMac = "N";
                            }
                        }
                    }
                    else
                    {
                        OT33_34C.resultadoMac = 13;
                        OT33_34C.recolocoCambioMac = " ";
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {
                        OT33_34C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT33_34C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));
                        }
                        else
                        {
                            OT33_34C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT33_34C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT33_34C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT33_34C.observNuevaMac = ObsGas(obs);
                    OT33_34C.anexosMac = obtenerAnexos(poliza, ot, ngnf, (DateTime)dt.GetDateTime(1), fe);
                    OT33_34C.codRechaMac = obtenerCodRechazo(poliza, ot, ngnf, (DateTime)dt.GetDateTime(1), fe);
                    for (int COM = OT33_34C.anexosMac.Count; COM <= 9; COM++)
                    {
                        OT33_34C.anexosMac.Add("  ");
                    }
                    for (int COM = OT33_34C.codRechaMac.Count; COM <= 9; COM++)
                    {
                        OT33_34C.codRechaMac.Add("    ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT33_34C = null;
                //MessageBox.Show(ex.Message + "\n  OT33_34");
            }
            finally
            {
                CNN.Close();
            }
            return OT33_34C;
        }
        public OT37_39_40 GENERAR_OT_37(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            //modificado 13/11/2020 --> trae usuario MAC
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT37_39_40 OT37C = new OT37_39_40();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT  REALIZO901, FREALIZADO901, OBSERV901, ESTADORET901, FIRMO901, CTAREA901, MEDCOLOCA901, CHABIT901, INTESC901, DOMINC901, MEDDIS901, CONFORME901, USGC901 FROM C901_UTILIZACION WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901='37') AND (C901_UTILIZACION.FE_EMISION901=@D2)AND (C901_UTILIZACION.NGNF901=@D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT37C.polExpMac = int.Parse(poliza);
                    OT37C.identPolExpMac = "P";
                    OT37C.contrataMac = 768;
                    OT37C.nusuarioMac = "EXT0002";
                    // OT37C.nusuarioMac = lector.GetString(12);
                    OT37C.firmoCteMac = dt.GetString(4);
                    try
                    {
                        OT37C.confCteMac = dt.GetString(11);
                    }
                    catch
                    {
                        OT37C.confCteMac = "SI";
                    }
                    if (dt.GetString(0) == "R")
                    {
                        OT37C.resultadoMac = 1;
                    }
                    else
                    {
                        OT37C.resultadoMac = 2;
                        for (int cv = 0; cv <= 2; cv++)
                        {
                            OT37C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT37C.colorMac.Add(".".PadLeft(15, ' '));
                            OT37C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {
                        OT37C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT37C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));
                        }
                        else
                        {
                            OT37C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT37C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT37C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT37C.observNuevaMac = ObsGas(obs);
                    if (dt.GetValue(3) == null)
                    {
                        OT37C.estaRetiMac = 0;
                    }
                    else
                    {
                        if (dt.GetString(3) != "")
                        {
                            OT37C.estaRetiMac = float.Parse(dt.GetString(3));
                        }
                        else { OT37C.estaRetiMac = 0; }
                    }
                    OT37C.cantHabitantesMac = dt.GetInt32(7);
                    OT37C.intensidadEscapeMac = dt.GetString(8);
                    OT37C.direccionMac = " ".ToString().PadLeft(50, ' ');
                    OT37C.entreCallesMac = " ".ToString().PadLeft(50, ' ');
                    OT37C.localidadMac = "000";
                    OT37C.partidoMac = "  ";
                    OT37C.numeroMedidorMac = 0;
                    OT37C.marcaMac = "  ";
                    OT37C.capacidadMac = "    ";
                    OT37C.esferasMac = 0;
                    OT37C.estadoMac = 0;
                    OT37C.escapeMac = "N";
                    // traio los codigos anexos
                    OT37C.anexosMac = obtenerAnexos(poliza, "37", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    //COMIENZO A LLENAR LOS SI-NO
                    //1-DOMICILIO INCORRECTO -- SE PASA
                    //2-MEDIDOR NO CORRESPONDE -- SE PASA
                    //3-FUNCIONAMIENTO CORRECTO -- SE PASAS
                    //4-SE ENCONTRO ESCAPE EN CAÑERIA INTERNA -NO SE UTILIZA
                    if (dt.GetString(0) == "R")
                    {
                        //string MedidorFunciona = obtenerFuncionamedidor(poliza,"37",ngnf, (DateTime)lector.GetDateTime(1),fe);
                        //OT37C.si2Mac.Add(" ");
                        //OT37C.no2Mac.Add("X");
                        //OT37C.si2Mac.Add(" ");
                        //OT37C.no2Mac.Add("X");
                        //1-DOMICILIO INCORRECTO
                        if (dt.GetString(9) == "NO")
                        {
                            OT37C.si2Mac.Add(" ");
                            OT37C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT37C.si2Mac.Add("X");
                            OT37C.no2Mac.Add(" ");
                            //OT37C.anexosMac.Add("61"); // NO PASO EL CODIGO ANEXO
                        }
                        //2-MEDIDOR INCORRECTO
                        if (dt.GetString(10) == "NO")
                        {
                            OT37C.si2Mac.Add(" ");
                            OT37C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT37C.si2Mac.Add("X");
                            OT37C.no2Mac.Add(" ");
                            // OT37C.anexosMac.Add("60"); //NO PASO EL CODIGO ANEXO
                        }
                        //3-FUNCIONAMIENTO DE MEDIDOR
                        if (obtenerFuncionamedidor(poliza, "37", ngnf, (DateTime)dt.GetDateTime(1), fe) == "NO")
                        {
                            OT37C.si2Mac.Add(" ");
                            OT37C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT37C.si2Mac.Add("X");
                            OT37C.no2Mac.Add(" ");
                        }
                        //4-ESPAPE EN CAÑERIA NO SE UTILIZA
                        OT37C.si2Mac.Add(" ");
                        OT37C.no2Mac.Add("X");
                    }
                    //RELLENO ANEXOS 
                    for (int cv = OT37C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT37C.anexosMac.Add("  ");
                    }
                    //RELLENO SI/NO
                    for (int cv = OT37C.si2Mac.Count; cv <= 5; cv++)
                    {
                        OT37C.si2Mac.Add(" ");
                        OT37C.no2Mac.Add(" ");
                    }
                    //RELLENO CODIGO DE VIVIENDA
                    for (int cv = OT37C.cdVivMac.Count; cv <= 9; cv++)
                    {
                        OT37C.cdVivMac.Add("00");
                        OT37C.colorMac.Add("".PadLeft(15, ' '));
                        OT37C.materialMac.Add("".PadLeft(15, ' '));
                    }
                }
            }
            catch (Exception ex)
            {
                OT37C = null;
                //MessageBox.Show(ex.Message + "\n OT37");
            }
            finally
            {
                CNN.Close();
            }
            return OT37C;
        }
        public OT37_39_40 GENERAR_OT_39(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;

            OT37_39_40 OT39C = new OT37_39_40();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT  REALIZO901, FREALIZADO901, OBSERV901, ESTADORET901, FIRMO901, CTAREA901, MEDCOLOCA901, CHABIT901, INTESC901, DOMINC901, MEDDIS901, CONFORME901, USGC901 FROM C901_UTILIZACION WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901='39') AND (C901_UTILIZACION.FE_EMISION901=@D2)AND (C901_UTILIZACION.NGNF901=@D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT39C.polExpMac = int.Parse(poliza);
                    OT39C.identPolExpMac = "P";
                    OT39C.contrataMac = 768;
                    OT39C.agenteMac = 0;
                    OT39C.nusuarioMac = "EXT0002";
                    //OT39C.nusuarioMac = lector.GetString(12);
                    OT39C.firmoCteMac = dt.GetString(4);
                    try
                    {
                        OT39C.confCteMac = dt.GetString(11);
                    }
                    catch
                    {
                        OT39C.confCteMac = "SI";
                    }
                    if (dt.GetString(0) == "R")
                    {
                        OT39C.resultadoMac = 1;
                    }
                    else
                    {
                        OT39C.resultadoMac = 2;
                        for (int cv = 0; cv <= 2; cv++)
                        {
                            OT39C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT39C.colorMac.Add(".".PadLeft(15, ' '));
                            OT39C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {
                        OT39C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT39C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));

                        }
                        else
                        {
                            OT39C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT39C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT39C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT39C.observNuevaMac = ObsGas(obs);
                    if (dt.GetValue(3) == null)
                    {
                        OT39C.estaRetiMac = 0;
                    }
                    else
                    {
                        if (dt.GetString(3) != "")
                        {
                            OT39C.estaRetiMac = float.Parse(dt.GetString(3));
                        }
                        else
                        {
                            OT39C.estaRetiMac = 0;
                        }
                    }
                    OT39C.cantHabitantesMac = dt.GetInt32(7);
                    OT39C.intensidadEscapeMac = dt.GetString(8);
                    OT39C.direccionMac = " ".ToString().PadLeft(50, ' ');
                    OT39C.entreCallesMac = " ".ToString().PadLeft(50, ' ');
                    OT39C.localidadMac = "000";
                    OT39C.partidoMac = "  ";
                    OT39C.numeroMedidorMac = 0;
                    OT39C.marcaMac = "  ";
                    OT39C.capacidadMac = "    ";
                    OT39C.esferasMac = 0;
                    OT39C.estadoMac = 0;
                    OT39C.escapeMac = " ";
                    // traio los codigos anexos
                    OT39C.anexosMac = obtenerAnexos(poliza, "39", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    //LLENO LOS SI-NO
                    //1-DOMICILIO INCORRECTO
                    //2-MEDIDOR INCORRECTO
                    //3-FUNCIONAMIENTO CORRECTO
                    //4-SE CAMBIO MEDIDOR
                    //5-SE MODIFICO TOMA EN NICHO--NO SE UTILIZA
                    //6-SE ENCONTRO ESCAPE EN CAÑERIA INTERNA --NO SE UTILIZA
                    if (dt.GetString(0) == "R")
                    {
                        //1-DOMICILIO INCORRECTO
                        if (dt.GetString(9) == "NO")
                        {
                            OT39C.si2Mac.Add(" ");
                            OT39C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT39C.si2Mac.Add("X");
                            OT39C.no2Mac.Add(" ");
                            // OT39C.anexosMac.Add("61");
                        }
                        //2-MEDIDOR INCORRECTO
                        if (dt.GetString(10) == "NO")
                        {
                            OT39C.si2Mac.Add(" ");
                            OT39C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT39C.si2Mac.Add("X");
                            OT39C.no2Mac.Add(" ");
                            // OT39C.anexosMac.Add("60");
                        }
                        //3-FUNCIONAMIENTO CORRECTO
                        if (obtenerFuncionamedidor(poliza, "39", ngnf, (DateTime)dt.GetDateTime(1), fe) == "NO")
                        {
                            OT39C.si2Mac.Add(" ");
                            OT39C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT39C.si2Mac.Add("X");
                            OT39C.no2Mac.Add(" ");
                        }
                        //4-SE CAMBIO MEDIDOR
                        if (dt.GetString(6) != "")
                        {
                            OT39C.si2Mac.Add("X");
                            OT39C.no2Mac.Add(" ");
                        }
                        else
                        {
                            OT39C.si2Mac.Add(" ");
                            OT39C.no2Mac.Add("X");
                        }
                        //5-SE MODIFIO TOMAS
                        OT39C.si2Mac.Add(" ");
                        OT39C.no2Mac.Add("X");
                        //6-SE ENCONTRO ESCAPE EN CAÑERIA INTERNA
                        OT39C.si2Mac.Add(" ");
                        OT39C.no2Mac.Add("X");

                    }
                    //RELLENO LOS SI/NO
                    for (int c = OT39C.si2Mac.Count; c <= 5; c++)
                    {
                        OT39C.si2Mac.Add(" ");
                        OT39C.no2Mac.Add(" ");
                    }
                    //RELLENO LA VIVIENDA
                    for (int c = OT39C.colorMac.Count; c <= 9; c++)
                    {
                        OT39C.cdVivMac.Add("00");
                        OT39C.colorMac.Add(" ".PadLeft(15, ' '));
                        OT39C.materialMac.Add(" ".PadLeft(15, ' '));
                    }
                    //RELLENO LOS DODIGOS ANEXOS
                    for (int c = OT39C.anexosMac.Count; c <= 9; c++)
                    {
                        OT39C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT39C = null;
                //MessageBox.Show(ex.Message + "\n OT39");
            }
            finally
            {
                CNN.Close();

            }
            return OT39C;
        }
        public OT37_39_40 GENERAR_OT_40(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            //modificado 13/10/2020 --> trae agente sgc
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT37_39_40 OT40C = new OT37_39_40();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT  REALIZO901, FREALIZADO901, OBSERV901, ESTADORET901, FIRMO901, CTAREA901, MEDCOLOCA901, CHABIT901, INTESC901, DOMINC901, MEDDIS901, CONFORME901, USGC901 FROM C901_UTILIZACION WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901='40') AND (C901_UTILIZACION.FE_EMISION901=@D2)AND (C901_UTILIZACION.NGNF901=@D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT40C.polExpMac = int.Parse(poliza);
                    OT40C.identPolExpMac = "P";
                    OT40C.agenteMac = 0;
                    OT40C.contrataMac = 768;
                    //OT40C.nusuarioMac = dt.GetString(12);
                    OT40C.nusuarioMac = "EXT0002";
                    OT40C.firmoCteMac = dt.GetString(4);
                    try
                    {
                        OT40C.confCteMac = dt.GetString(11);
                    }
                    catch
                    {
                        OT40C.confCteMac = "SI";
                    }
                    if (dt.GetString(0) == "R")
                    {
                        OT40C.resultadoMac = 1;
                    }
                    else
                    {
                        OT40C.resultadoMac = 2;
                        for (int cv = 0; cv <= 2; cv++)
                        {
                            OT40C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT40C.colorMac.Add(".".PadLeft(15, ' '));
                            OT40C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {
                        OT40C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT40C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));
                        }
                        else
                        {
                            OT40C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT40C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT40C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT40C.observNuevaMac = ObsGas(obs);
                    OT40C.direccionMac = " ".ToString().PadLeft(50, ' ');
                    OT40C.entreCallesMac = " ".ToString().PadLeft(50, ' ');
                    OT40C.localidadMac = "000";
                    OT40C.partidoMac = "  ";
                    OT40C.numeroMedidorMac = 0;
                    OT40C.marcaMac = "  ";
                    OT40C.capacidadMac = "    ";
                    OT40C.esferasMac = 0;
                    OT40C.estadoMac = 0;
                    OT40C.escapeMac = " ";
                    if (dt.GetValue(3) == null)
                    {
                        OT40C.estaRetiMac = 0;
                    }
                    else
                    {
                        if (dt.GetString(3) != "")
                        {
                            OT40C.estaRetiMac = float.Parse(dt.GetString(3));
                        }
                        else { OT40C.estaRetiMac = 0; }
                    }
                    OT40C.cantHabitantesMac = dt.GetInt32(7);
                    OT40C.intensidadEscapeMac = dt.GetString(8);
                    //TRAIGO LOS CODIGOS ANEXOS
                    OT40C.anexosMac = obtenerAnexos(poliza, "40", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    //GENERO LOS SI-NO
                    //1-DOMICIILIO INCORRECTO
                    //2-MEDIDOR INCORRECTO
                    if (dt.GetString(0) == "R")
                    {
                        //1-DOMICILIO INCORRECTO
                        if (dt.GetString(9) == "NO")
                        {
                            OT40C.si2Mac.Add(" ");
                            OT40C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT40C.si2Mac.Add("X");
                            OT40C.no2Mac.Add(" ");
                            //OT40C.anexosMac.Add("61");
                        }
                        //2-MEDIDOR INCORRECTO
                        if (dt.GetString(10) == "NO")
                        {
                            OT40C.si2Mac.Add(" ");
                            OT40C.no2Mac.Add("X");
                        }
                        else
                        {
                            OT40C.si2Mac.Add("X");
                            OT40C.no2Mac.Add(" ");
                            //OT40C.anexosMac.Add("60");
                        }
                    }
                    //RELLENO LOS SI/NO
                    for (int c = OT40C.si2Mac.Count; c <= 5; c++)
                    {
                        OT40C.si2Mac.Add(" ");
                        OT40C.no2Mac.Add(" ");
                    }
                    //RELLENOS LOS CODIGOS DE VIVIENDA
                    for (int c = OT40C.colorMac.Count; c <= 9; c++)
                    {
                        OT40C.cdVivMac.Add("00");
                        OT40C.colorMac.Add(" ".PadLeft(15, ' '));
                        OT40C.materialMac.Add(" ".PadLeft(15, ' '));
                    }
                    //RELLENOS LOS CODIGOS ANEXOS
                    for (int c = OT40C.anexosMac.Count; c <= 9; c++)
                    {
                        OT40C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT40C = null;
                //MessageBox.Show(ex.Message + "\n OT40");
            }
            finally
            {
                CNN.Close();
            }
            return OT40C;
        }
        public OT42_43 GENERAR_OT_42_43(string poliza, DateTime fe, string ngnf, DateTime feCliente, string OT)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT42_43 OT42_43C = new OT42_43();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB901,PARTE901, REALIZO901, FREALIZADO901, OBSERV901,ESTADORET901, FIRMO901, FE_EMISION901,NGNF901, CTAREA901,CONFORME901,USGC901,MEDCOLOCA901, ESTADOCOLA901 FROM C901_UTILIZACION WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901=@D2) AND (C901_UTILIZACION.FE_EMISION901=@D3)AND (C901_UTILIZACION.NGNF901=@D4) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", OT);
                ADT.Parameters.AddWithValue("D3", fe);
                ADT.Parameters.AddWithValue("D4", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT42_43C.polExpMac = int.Parse(poliza);
                    OT42_43C.agenteMac = 0;
                    OT42_43C.contrataMac = 768;
                    OT42_43C.identPolExpMac = "P";
                    // OT45C.nusuarioMac = dt.GetString(11);
                    OT42_43C.nusuarioMac = "EXT0002";
                    if (dt.GetString(2) == "R")
                    {
                        OT42_43C.resultadoMac = 1;
                        OT42_43C.firmoCteMac = dt.GetString(6);
                        try
                        {
                            OT42_43C.confCteMac = dt.GetString(10);
                        }
                        catch
                        {
                            OT42_43C.confCteMac = "SI";
                        }
                         OT42_43C.numeroColoMac = int.Parse(dt.GetString(12));
                        OT42_43C.estadoColoMac = int.Parse(dt.GetString(13));
                        MedColoca medidor = obtenerMedidorNaturgy(dt.GetString(12));
                        if (medidor.existe)
                        {
                            OT42_43C.capacColoMac = medidor.Capacidad.ToString().PadLeft(4, '0');
                            OT42_43C.marcaColoMac = medidor.MarcaMedidor.ToString().PadLeft(2, '0');
                            OT42_43C.unidMedContColoMac = medidor.Esferas;
                        }
                        else
                        {
                            OT42_43C.capacColoMac = "";
                            OT42_43C.marcaColoMac = "";
                            OT42_43C.unidMedContColoMac = 0;
                        }
                        //1-Se Cambio LLAVE
                        OT42_43C.no2Mac.Add("X");
                        OT42_43C.si2Mac.Add(" ");
                        //2-Se modifico toma en nicho
                        OT42_43C.no2Mac.Add("X");
                        OT42_43C.si2Mac.Add(" ");
                        //3-Se encontro escape en cañeria interna
                        OT42_43C.no2Mac.Add("X");
                        OT42_43C.si2Mac.Add(" ");
                        //RELLENO LOS SI/NO
                        for (int c = OT42_43C.si2Mac.Count; c <= 5; c++)
                        {
                            OT42_43C.si2Mac.Add(" ");
                            OT42_43C.no2Mac.Add(" ");
                        }
                    }
                    else
                    {
                        OT42_43C.resultadoMac = 2;
                        OT42_43C.firmoCteMac = dt.GetString(6);
                        OT42_43C.confCteMac = dt.GetString(10);
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT42_43C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT42_43C.colorMac.Add(".".PadLeft(15, ' '));
                            OT42_43C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(4).ToUpper();
                    // DateTime fer = dt.GetDateTime(3);
                    if (dt.GetDateTime(3) > feCliente)
                    {
                        OT42_43C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(3).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT42_43C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                        }
                        else
                        {
                            OT42_43C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT42_43C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT42_43C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT42_43C.observNuevaMac = ObsGas(obs);
                    OT42_43C.anexosMac = obtenerAnexos(poliza, OT, ngnf, (DateTime)dt.GetDateTime(3), fe);
                    for (int cv = OT42_43C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT42_43C.cdVivMac.Add("00");
                        OT42_43C.colorMac.Add("".PadLeft(15, ' '));
                        OT42_43C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT42_43C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT42_43C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT42_43C = null;
                //MessageBox.Show(ex.Message + "\n OT45");
            }
            finally
            {
                CNN.Close();
            }
            return OT42_43C;
        }
        public OT45 GENERAR_OT_45(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT45 OT45C = new OT45();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB901,PARTE901, REALIZO901, FREALIZADO901, OBSERV901,ESTADORET901, FIRMO901, FE_EMISION901,NGNF901, CTAREA901,CONFORME901,USGC901 FROM C901_UTILIZACION WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901='45') AND (C901_UTILIZACION.FE_EMISION901=@D2)AND (C901_UTILIZACION.NGNF901=@D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT45C.polExpMac = int.Parse(poliza);
                    OT45C.agenteMac = 0;
                    OT45C.contrataMac = 768;
                    OT45C.identPolExpMac = "P";
                    // OT45C.nusuarioMac = dt.GetString(11);
                    OT45C.nusuarioMac = "EXT0002";
                    if (dt.GetString(2) == "R")
                    {
                        OT45C.resultadoMac = 1;
                        OT45C.firmoCteMac = dt.GetString(6);
                        try
                        {
                            OT45C.confCteMac = dt.GetString(10);
                        }
                        catch
                        {

                            OT45C.confCteMac = "SI";
                        }
                    }
                    else
                    {
                        OT45C.resultadoMac = 2;
                        // OT45C.firmoCteMac = dt.GetString(6);
                        //OT45C.confCteMac = dt.GetString(10);
                        OT45C.firmoCteMac = "NO";
                        OT45C.confCteMac = "NO";
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT45C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT45C.colorMac.Add(".".PadLeft(15, ' '));
                            OT45C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(4).ToUpper();
                    // DateTime fer = dt.GetDateTime(3);
                    if (dt.GetDateTime(3) > feCliente)
                    {
                        OT45C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(3).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT45C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                        }
                        else
                        {
                            OT45C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT45C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT45C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT45C.observNuevaMac = ObsGas(obs);
                    if (dt.GetValue(5) == null)
                    {
                        OT45C.lecturaMac = 0;
                    }
                    else
                    {
                        try
                        {
                            OT45C.lecturaMac = float.Parse(dt.GetString(5));
                        }
                        catch
                        {
                            OT45C.lecturaMac = 0;
                        }
                    }
                    OT45C.anexosMac = obtenerAnexos(poliza, "45", ngnf, (DateTime)dt.GetDateTime(3), fe);
                    for (int cv = OT45C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT45C.cdVivMac.Add("00");
                        OT45C.colorMac.Add("".PadLeft(15, ' '));
                        OT45C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT45C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT45C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT45C = null;
                //MessageBox.Show(ex.Message + "\n OT45");
            }
            finally
            {
                CNN.Close();
            }
            return OT45C;
        }
        public OT46 GENERAR_OT_46(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT46 OT46C = new OT46();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT REALIZO901, FREALIZADO901, OBSERV901, ESTADORET901, FIRMO901, CONFORME901, USGC901 FROM C901_UTILIZACION WHERE (PARTE901 = @D1) AND (TIPO_TRAB901 = '46') AND (FE_EMISION901 = @D2) AND (NGNF901 = @D3) ORDER BY PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT46C.polExpMac = int.Parse(poliza);
                    OT46C.contrataMac = 768;
                    OT46C.agenteMac = 0;
                    OT46C.identPolExpMac = "P";
                    //OT46C.nusuarioMac = dt.GetString(6);
                    OT46C.nusuarioMac = "EXT0002";
                    OT46C.firmoCteMac = dt.GetString(4);
                    try
                    {
                        OT46C.confCteMac = dt.GetString(5);
                    }
                    catch
                    {
                        OT46C.confCteMac = "SI";
                    }
                    if (dt.GetString(0) == "R")
                    {
                        OT46C.resultadoMac = 1;
                        if (dt.GetValue(3) == null)
                        {
                            OT46C.estadoRetiMac = 0;
                        }
                        else
                        {
                            if (dt.GetString(3) == "")
                            {
                                OT46C.estadoRetiMac = 0;
                            }
                            else
                            {
                                OT46C.estadoRetiMac = float.Parse(dt.GetString(3));
                            }
                        }
                    }
                    else
                    {
                        OT46C.resultadoMac = 2;
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT46C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT46C.colorMac.Add(".".PadLeft(15, ' '));
                            OT46C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    string obs = dt.GetString(2).ToUpper();
                    if (dt.GetDateTime(1) > feCliente)
                    {
                        OT46C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT46C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));

                        }
                        else
                        {
                            OT46C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT46C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT46C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT46C.observNuevaMac = ObsGas(obs);
                    OT46C.anexosMac = obtenerAnexos(poliza, "46", ngnf, (DateTime)dt.GetDateTime(1), fe);
                    for (int cv = OT46C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT46C.anexosMac.Add("  ");
                    }
                    for (int cv = OT46C.cdVivMac.Count; cv <= 9; cv++)
                    {
                        OT46C.cdVivMac.Add("00");
                        OT46C.colorMac.Add("".PadLeft(15, ' '));
                        OT46C.materialMac.Add("".PadLeft(15, ' '));
                    }
                }
            }
            catch (Exception ex)
            {
                OT46C = null;
                // MessageBox.Show(ex.Message + "\n Error en generar OT46");
            }
            finally
            {
                CNN.Close();
            }
            return OT46C;
        }
        public OT49 GENERAR_OT_49(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT49 OT49C = new OT49();
            //try
            //{
            CNN.Open();
            SqlCommand ADT = new SqlCommand("SELECT C901_UTILIZACION.REALIZO901, C901_UTILIZACION.FREALIZADO901, C901_UTILIZACION.OBSERV901, C900_TAREAS.NMEDIDOR900, C900_TAREAS.CAPACIDAD900, C900_TAREAS.MARCA900,  C901_UTILIZACION.ESTADORET901,C900_TAREAS.ESFMED900, C901_UTILIZACION.FIRMO901, C901_UTILIZACION.CONFORME901,C901_UTILIZACION.USGC901 FROM C901_UTILIZACION INNER JOIN C900_TAREAS ON C901_UTILIZACION.CCONT901 = C900_TAREAS.CCONT900 AND C901_UTILIZACION.TIPO_TRAB901 = C900_TAREAS.TIPO_TRAB900 AND C901_UTILIZACION.NGNF901 = C900_TAREAS.NGNF900 AND  C901_UTILIZACION.PARTE901 = C900_TAREAS.NPARTE900 AND C901_UTILIZACION.FE_EMISION901 = C900_TAREAS.FE_EMISION900 WHERE (C901_UTILIZACION.PARTE901 = @D1) AND (C901_UTILIZACION.TIPO_TRAB901 = N'49') AND (C901_UTILIZACION.FE_EMISION901 = @D2) AND (C901_UTILIZACION.NGNF901 = @D3) ORDER BY C901_UTILIZACION.PARTE901", CNN);
            ADT.Parameters.AddWithValue("D1", poliza);
            ADT.Parameters.AddWithValue("D2", fe);
            ADT.Parameters.AddWithValue("D3", ngnf);
            dt = ADT.ExecuteReader();
            if (dt.Read())
            {
                OT49C.polExpMac = int.Parse(poliza);
                OT49C.agenteMac = 0;
                OT49C.contrataMac = 768;
                OT49C.identPolExpMac = "P";
                //OT49C.nusuarioMac = dt.GetString(10);
                OT49C.nusuarioMac = "EXT0002";
                if (dt.GetString(0) == "R")
                {
                    OT49C.resultadoMac = 1;
                    OT49C.numeroColoMac = dt.GetString(3);
                    OT49C.capacColoMac = dt.GetString(4);
                    OT49C.marcaColoMac = dt.GetString(5);
                    try
                    {
                        OT49C.unidMedContColoMac = dt.GetInt32(7); ;
                    }
                    catch
                    {
                        OT49C.unidMedContColoMac = 5;
                    }
                    if (dt.GetValue(6) == null)
                    {
                        OT49C.estadoColoMac = 0;
                    }
                    else
                    {
                        if (dt.GetString(6) == "")
                        {
                            OT49C.estadoColoMac = 0;
                        }
                        else
                        {
                            OT49C.estadoColoMac = float.Parse(dt.GetString(6));
                        }
                    }
                }
                else
                {
                    OT49C.resultadoMac = 2;
                }
                OT49C.firmoCteMac = dt.GetString(8);
                try
                {
                    OT49C.confCteMac = dt.GetString(9);
                }
                catch
                {
                    OT49C.confCteMac = "SI";
                }
                string obs = dt.GetString(2).ToUpper();
                if (dt.GetDateTime(1) > feCliente)
                {
                    OT49C.feRealizaMac = dt.GetDateTime(1).ToString("yyyyMMdd");
                    if (int.Parse(dt.GetDateTime(1).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                    {
                        OT49C.hoRealizMac = float.Parse(dt.GetDateTime(1).ToString("HHmm"));

                    }
                    else
                    {
                        OT49C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                    }
                }
                else
                {
                    OT49C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                    OT49C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                    if (obs.Length != 0)
                    {
                        obs = obs + "- FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        obs = "FECHA REAL " + dt.GetDateTime(1).ToString("dd/MM/yyyy HH:mm");
                    }
                }
                OT49C.observNuevaMac = ObsGas(obs);
                OT49C.anexosMac = obtenerAnexos(poliza, "49", ngnf, (DateTime)dt.GetDateTime(1), fe);
                OT49C.observCepo = " ".PadLeft(50, ' ');
                OT49C.cepo = obtenerTipoCierre(poliza, "49", ngnf, (DateTime)dt.GetDateTime(1), fe);
                for (int cv = OT49C.anexosMac.Count; cv <= 9; cv++)
                {
                    OT49C.anexosMac.Add("  ");
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    OT49C = null;
            //    //   MessageBox.Show(ex.Message + "\n Error en generar  OT49");
            //}
            //finally
            //{
            CNN.Close();
            //}
            return OT49C;
        }
        public OT11_17_47_54 GENERAR_OT_47(string poliza, DateTime fe, string ngnf, DateTime feCliente)
        {
            //Modificado 13/11/2020 --> trae usuario mac
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            SqlDataReader dt = null;
            OT11_17_47_54 OT47C = new OT11_17_47_54();
            try
            {
                CNN.Open();
                SqlCommand ADT = new SqlCommand("SELECT TIPO_TRAB901,PARTE901, REALIZO901, FREALIZADO901, OBSERV901,ESTADORET901, FIRMO901, FE_EMISION901,NGNF901, CTAREA901,CONFORME901, USGC901 FROM C901_UTILIZACION WHERE (PARTE901 = @D1) AND (TIPO_TRAB901='47') AND (FE_EMISION901=@D2)AND (NGNF901=@D3) ORDER BY PARTE901", CNN);
                ADT.Parameters.AddWithValue("D1", poliza);
                ADT.Parameters.AddWithValue("D2", fe);
                ADT.Parameters.AddWithValue("D3", ngnf);
                dt = ADT.ExecuteReader();
                if (dt.Read())
                {
                    OT47C.polExpMac = int.Parse(poliza);
                    OT47C.agenteMac = 0;
                    OT47C.identPolExpMac = "P";
                    OT47C.contrataMac = 768;
                    OT47C.nusuarioMac = dt.GetString(11);
                    string obs = dt.GetString(4).ToUpper();
                    if (dt.GetDateTime(3) > feCliente)
                    {
                        OT47C.feRealizaMac = dt.GetDateTime(3).ToString("yyyyMMdd");
                        if (int.Parse(dt.GetDateTime(3).ToString("HHmm")) > int.Parse(feCliente.ToString("HHmm")))
                        {
                            OT47C.hoRealizMac = float.Parse(dt.GetDateTime(3).ToString("HHmm"));
                        }
                        else
                        {
                            OT47C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        }
                    }
                    else
                    {
                        OT47C.feRealizaMac = feCliente.ToString("yyyyMMdd");
                        OT47C.hoRealizMac = float.Parse(feCliente.AddMinutes(30).ToString("HHmm"));
                        if (obs.Length != 0)
                        {
                            obs = obs + "- FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            obs = "FECHA REAL " + dt.GetDateTime(3).ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    OT47C.observNuevaMac = ObsGas(obs);
                    OT47C.anexosMac = obtenerAnexos(poliza, "47", ngnf, (DateTime)dt.GetDateTime(3), fe);
                    OT47C.firmoCteMac = dt.GetString(6);
                    try
                    {
                        OT47C.confCteMac = dt.GetString(10);
                    }
                    catch
                    {
                        OT47C.confCteMac = "SI";
                    }
                    if (dt.GetString(2) == "R")
                    {
                        OT47C.resultadoMac = 1;
                    }
                    else
                    {
                        OT47C.resultadoMac = 2;
                        for (int cv = 0; cv <= 3; cv++)
                        {
                            OT47C.cdVivMac.Add((cv + 1).ToString().PadLeft(2, '0'));
                            OT47C.colorMac.Add(".".PadLeft(15, ' '));
                            OT47C.materialMac.Add(".".PadLeft(15, ' '));
                        }
                    }
                    if (dt.GetValue(5) == null)
                    {
                        OT47C.estadoRetiMac = 0;
                    }
                    else
                    {
                        try
                        {
                            OT47C.estadoRetiMac = float.Parse(dt.GetString(5));
                        }
                        catch
                        {
                            OT47C.estadoRetiMac = 0;
                        }
                    }

                    for (int cv = OT47C.colorMac.Count; cv <= 9; cv++)
                    {
                        OT47C.cdVivMac.Add("00");
                        OT47C.colorMac.Add("".PadLeft(15, ' '));
                        OT47C.materialMac.Add("".PadLeft(15, ' '));
                    }
                    for (int cv = OT47C.anexosMac.Count; cv <= 9; cv++)
                    {
                        OT47C.anexosMac.Add("  ");
                    }
                }
            }
            catch (Exception ex)
            {
                OT47C = null;
                //MessageBox.Show(ex.Message + "\n OT47");
            }
            finally
            {
                CNN.Close();
            }

            return OT47C;
        }
        #endregion
        #region "Funciones Extra"
        public GeoExgadet RetornarGeo(string nparte)
        {
            CadenaConexion cadena = new CadenaConexion();
            GeoExgadet migeo = new GeoExgadet();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT LATITUD012, LONGITUD012, DATO012,ncodRetorno FROM Z012_CORDENADAS WHERE (POLIZA012 = @D1)", cnn);
                adt.Parameters.AddWithValue("D1", nparte);
                SqlDataReader lector = adt.ExecuteReader();

                while (lector.Read())
                {

                    migeo.Parte = nparte;
                    migeo.latitud = lector.GetValue(0).ToString();
                    migeo.longitud = lector.GetValue(1).ToString();
                    migeo.existe = true;

                    if (lector.GetValue(2) != null) { migeo.Origen = lector.GetString(2); } else { migeo.Origen = "EX"; }
                    try
                    {
                        migeo.ncodRetorno = lector.GetString(3);
                    }
                    catch
                    {
                        migeo.ncodRetorno = "-";
                    }


                }



            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                migeo.existe = false;
                //= null/* TODO Change to default(_) if this is not a reference type */;
            }
            finally
            {
                cnn.Close();
            }
            return migeo;
        }
        private ArrayList ObsGas(string mitexto)
        {
            ArrayList final = new ArrayList();
            mitexto = mitexto.ToUpper();
            mitexto = mitexto.Replace("Ñ", "NI").Replace('\n', ' ').Replace('\r', ' ');
            string obs60 = "";
            string[] textoArray = mitexto.Split(' ');

            int sumador = 0;
            for (int i = 0; i <= textoArray.Length - 1; i++)
            {
                if ((sumador + textoArray[i].Length + 1) <= 60)
                {
                    if (obs60.Length == 0)
                    {
                        obs60 = textoArray[i].ToString();
                    }
                    else
                    {
                        obs60 = obs60 + " " + textoArray[i].ToString();
                    }
                    sumador = obs60.Length;
                }
                else
                {
                    // MessageBox.Show(obs60.Length.ToString());
                    final.Add(obs60.PadRight(60, ' '));
                    obs60 = textoArray[i].ToString();
                    sumador = textoArray[i].Length;
                }
            }
            if (obs60.Length != 0)
            {
                //MessageBox.Show(obs60.Length.ToString());
                final.Add(obs60.PadRight(60, ' '));
            }

            if (final.Count > 4) for (int i = 4; i <= final.Count - 1; i++) final.RemoveAt(i);
            for (int c = final.Count; c <= 3; c++)
            {
                final.Add("".PadRight(60, ' '));

            }


            return final;
        }
        private ArrayList obtenerAnexos(string poliza, string ot, string ngnf, DateTime fr, DateTime fe)
        {
            ArrayList array = new ArrayList();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                DataTable TABLA_DETALLE = new DataTable();
                cnn.Open();
                SqlDataAdapter ADT = new SqlDataAdapter("SELECT T153_CONVERCION_MAC.CODANEXO153 FROM T104_PUNTO_OPERARIO_OT INNER JOIN T153_CONVERCION_MAC ON T104_PUNTO_OPERARIO_OT.CCONT104 = T153_CONVERCION_MAC.CCONT153 AND T104_PUNTO_OPERARIO_OT.CTAREA104 = T153_CONVERCION_MAC.CTAREA153 WHERE (T104_PUNTO_OPERARIO_OT.FECHA104 = @FR) AND (T104_PUNTO_OPERARIO_OT.NTAREA104 =@POLIZA) AND (T104_PUNTO_OPERARIO_OT.TIPO_TRAB104 = @OT) AND (T104_PUNTO_OPERARIO_OT.FE_GENERADO104 = @FE) AND (T104_PUNTO_OPERARIO_OT.NGNF104 = @NGNF) AND (T104_PUNTO_OPERARIO_OT.CCONT104 = N'001') AND (T153_CONVERCION_MAC.CODANEXO153 IS NOT NULL)", cnn);
                ADT.SelectCommand.Parameters.AddWithValue("FR", fr);
                ADT.SelectCommand.Parameters.AddWithValue("POLIZA", poliza);
                ADT.SelectCommand.Parameters.AddWithValue("OT", ot);
                ADT.SelectCommand.Parameters.AddWithValue("FE", fe);
                ADT.SelectCommand.Parameters.AddWithValue("NGNF", ngnf);
                ADT.Fill(TABLA_DETALLE);
                if (TABLA_DETALLE.Rows.Count != 0)
                {
                    for (int K = 0; K <= TABLA_DETALLE.Rows.Count - 1; K++)
                    {
                        string[] AD = TABLA_DETALLE.Rows[K][0].ToString().Trim().Split('-');
                        for (int A = 0; A <= AD.Length - 1; A++)
                            array.Add(AD[A]);
                    }
                }
            }
            // TABLA_DETALLE.Dispose()
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " obtener anexos");
            }
            finally
            {
                cnn.Close();
            }
            return array;
        }
        private string obtenerTipoCierre(string poliza, string ot, string ngnf, DateTime fr, DateTime fe)
        {
            string respuesta = " ";
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                DataTable TABLA_DETALLE = new DataTable();
                cnn.Open();
                SqlCommand ADT = new SqlCommand("SELECT T153_CONVERCION_MAC.TIPOCIERRE153 FROM T104_PUNTO_OPERARIO_OT INNER JOIN T153_CONVERCION_MAC ON T104_PUNTO_OPERARIO_OT.CCONT104 = T153_CONVERCION_MAC.CCONT153 AND T104_PUNTO_OPERARIO_OT.CTAREA104 = T153_CONVERCION_MAC.CTAREA153 WHERE (T104_PUNTO_OPERARIO_OT.FECHA104 = @FR) AND (T104_PUNTO_OPERARIO_OT.NTAREA104 =@POLIZA) AND (T104_PUNTO_OPERARIO_OT.TIPO_TRAB104 = @OT) AND (T104_PUNTO_OPERARIO_OT.FE_GENERADO104 = @FE) AND (T104_PUNTO_OPERARIO_OT.NGNF104 = @NGNF) AND (T104_PUNTO_OPERARIO_OT.CCONT104 = N'001') AND (T153_CONVERCION_MAC.TIPOCIERRE153 IS NOT NULL)", cnn);
                ADT.Parameters.AddWithValue("FR", fr);
                ADT.Parameters.AddWithValue("POLIZA", poliza);
                ADT.Parameters.AddWithValue("OT", ot);
                ADT.Parameters.AddWithValue("FE", fe);
                ADT.Parameters.AddWithValue("NGNF", ngnf);
                SqlDataReader LECTOR = ADT.ExecuteReader();
                if (LECTOR.Read())
                    respuesta = LECTOR.GetString(0);
            }
            // TABLA_DETALLE.Dispose()
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Obtener tipo de cierre");
            }
            finally
            {
                cnn.Close();
            }
            return respuesta;
        }
        private ArrayList obtenerCodRechazo(string poliza, string ot, string ngnf, DateTime fr, DateTime fe)
        {
            ArrayList array = new ArrayList();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                DataTable tabla = new DataTable();
                cnn.Open();
                SqlDataAdapter adt = new SqlDataAdapter("SELECT COD_RE149 FROM T149_COD_RECHAZO WHERE (CCONT149 = N'001') AND (TIPO_TRAB149 = @OT) AND (NGNF149 = @NGNF) AND (FE_EMISION149 = @FE) AND (NPARTE149 = @POLIZA) AND (FEC_REALI149 = @FR)", cnn);
                adt.SelectCommand.Parameters.AddWithValue("OT", ot);
                adt.SelectCommand.Parameters.AddWithValue("NGNF", ngnf);
                adt.SelectCommand.Parameters.AddWithValue("FE", fe);
                adt.SelectCommand.Parameters.AddWithValue("POLIZA", poliza);
                adt.SelectCommand.Parameters.AddWithValue("FR", fr);
                adt.Fill(tabla);
                for (var ART = 0; ART <= tabla.Rows.Count - 1; ART++)
                    array.Add(tabla.Rows[ART][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Obtener codigo de rechazo");
            }
            finally
            {
                cnn.Close();
            }
            return array;
        }
        private float obtenerAprobadoRechazado(string ctare, string cont)
        {
            float respuesta = 0;
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            try
            {
                CNN.Open();
                SqlCommand adt = new SqlCommand("SELECT RESULTMAC153 FROM T153_CONVERCION_MAC WHERE (CCONT153 = @D2) AND (CTAREA153 = @D1)", CNN);
                adt.Parameters.AddWithValue("D2", cont);
                adt.Parameters.AddWithValue("D1", ctare);
                SqlDataReader lector = adt.ExecuteReader();
                if (lector.Read())
                    respuesta = float.Parse(lector.GetString(0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Obtener aporbo Rechazo");

            }
            finally
            {
                CNN.Close();
            }
            return respuesta;
        }
        private string obtenerFuncionamedidor(string poliza, string ot, string ngnf, DateTime fr, DateTime fe)
        {
            string respuesta = "SI";
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            try
            {
                CNN.Open();
                SqlCommand ADT2 = new SqlCommand("SELECT T153_CONVERCION_MAC.MED_FUN153 FROM T104_PUNTO_OPERARIO_OT INNER JOIN T153_CONVERCION_MAC ON T104_PUNTO_OPERARIO_OT.CTAREA104 = T153_CONVERCION_MAC.CTAREA153 AND T104_PUNTO_OPERARIO_OT.CCONT104 = T153_CONVERCION_MAC.CCONT153 WHERE (T104_PUNTO_OPERARIO_OT.FE_GENERADO104 = @FE) AND (T104_PUNTO_OPERARIO_OT.NTAREA104 = @POLIZA) AND (T104_PUNTO_OPERARIO_OT.TIPO_TRAB104 = @OT) AND (T104_PUNTO_OPERARIO_OT.NGNF104 = @NG) AND (T104_PUNTO_OPERARIO_OT.FECHA104=@FR) AND (T153_CONVERCION_MAC.MED_FUN153 = N'NO')", CNN);
                ADT2.Parameters.AddWithValue("FE", fe.ToString());
                ADT2.Parameters.AddWithValue("POLIZA", poliza);
                ADT2.Parameters.AddWithValue("OT", ot);
                ADT2.Parameters.AddWithValue("NG", ngnf);
                ADT2.Parameters.AddWithValue("FR", (DateTime)fr);
                SqlDataReader lector2 = ADT2.ExecuteReader();
                if (lector2.Read())
                    respuesta = "NO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n funciona obtener funciona medidor");
            }
            finally
            {
                CNN.Close();
            }
            return respuesta;
        }
        private List<artefacto> obtenerArtefactos(string poliza, string ot, string ngnf, DateTime fe)
        {
            List<artefacto> art = new List<artefacto>();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            string clau = "NO";
            try
            {
                DataTable tabla = new DataTable();
                cnn.Open();
                SqlDataAdapter adt = new SqlDataAdapter("SELECT Z022_ARTEFACTOS_MAC.CARTMAC022 AS CODIGO, UBICACION.CODALT802 AS UBICACION, T148_ARTEFACTO_UTI.CANT_ART148, T148_ARTEFACTO_UTI.NPRECINTO148 FROM T148_ARTEFACTO_UTI INNER JOIN P802_PARAMETROS AS UBICACION ON T148_ARTEFACTO_UTI.UBICACION148 = UBICACION.CPARA802 INNER JOIN Z022_ARTEFACTOS_MAC ON T148_ARTEFACTO_UTI.CODART148 = Z022_ARTEFACTOS_MAC.CARTEXGA022 AND T148_ARTEFACTO_UTI.CALORIA148 >= Z022_ARTEFACTOS_MAC.KMIN022 AND T148_ARTEFACTO_UTI.CALORIA148 <= Z022_ARTEFACTOS_MAC.KMAX022 WHERE (T148_ARTEFACTO_UTI.CCONT148 = N'001') AND (T148_ARTEFACTO_UTI.TIPO_TRAB148 = @D1) AND (T148_ARTEFACTO_UTI.NGNF148 = @D2) AND (T148_ARTEFACTO_UTI.FE_EMISION148 = @D3) AND (T148_ARTEFACTO_UTI.NPARTE148 = @D4) AND (UBICACION.CTABLA802 = 46)", cnn);
                adt.SelectCommand.Parameters.AddWithValue("D1", ot);
                adt.SelectCommand.Parameters.AddWithValue("D2", ngnf);
                adt.SelectCommand.Parameters.AddWithValue("D3", fe);
                adt.SelectCommand.Parameters.AddWithValue("D4", poliza);

                adt.Fill(tabla);
                for (int a = 0; a <= tabla.Rows.Count - 1; a++)
                {
                    artefacto nuevo = new artefacto();
                    string[] codarray = tabla.Rows[a][0].ToString().Split('-');
                    if (tabla.Rows[a][3].ToString() == "0" || tabla.Rows[a][3].ToString() == "")
                        clau = "NO";
                    else
                        clau = "SI";
                    nuevo.tipo = codarray[0];
                    nuevo.codigo = codarray[1];
                    nuevo.clausurado = clau;
                    nuevo.cant = (int)tabla.Rows[a][2];
                    nuevo.ubicacion = tabla.Rows[a][1].ToString();
                    art.Add(nuevo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Obtener Artefactos");
                art = null;
            }
            finally
            {
                cnn.Close();
            }


            return art;
        }
        private MedColoca obtenerMedidorNaturgy(string nserie)
        {
            MedColoca mimedidor = new MedColoca();
            SqlConnection cnn = new SqlConnection(cadena.Almacen);
            // string clau = "NO";
            try
            {
                DataTable tabla = new DataTable();
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT T_MEDI_102.NSERIE_102, T_MEDI_102.CMATE_102, T_MEDI_102.ESFERA_102, T_MEDI_102.MARCA_102, M_MATE_002.CAPACIDAD_002 FROM T_MEDI_102 INNER JOIN M_MATE_002 ON T_MEDI_102.CMATE_102 = M_MATE_002.CMATE_002 WHERE (T_MEDI_102.NSERIE_102 = @D1)", cnn);
                adt.Parameters.AddWithValue("D1", nserie);
                SqlDataReader lector = adt.ExecuteReader();
                if (lector.Read())
                {
                    {
                        mimedidor.existe = true;
                        mimedidor.Esferas = lector.GetInt32(2);
                        mimedidor.MarcaMedidor = lector.GetString(3);
                        mimedidor.Capacidad = lector.GetInt32(4);
                    }
                }
            }
            catch (Exception ex)
            {
                mimedidor.existe = false;
                //MessageBox.Show(ex.Message + " Obtenermedidor de gas");
                // mimedidor = null/* TODO Change to default(_) if this is not a reference type */;
            }
            finally
            {
                cnn.Close();
            }
            return mimedidor;
        }
        public string getUrl(string OT, string CONT)
        {
            string uri = "";
            SqlConnection CNN = new SqlConnection(cadena.integrla);
            try
            {
                CNN.Open();
                SqlCommand ADT2 = new SqlCommand("SELECT URL023 FROM Z023_URL_MAC WHERE (CCONT023 = @CONT) AND (CMOTIVO023 =@OT)", CNN);
                ADT2.Parameters.AddWithValue("CONT", CONT.ToString());
                ADT2.Parameters.AddWithValue("OT", OT.ToString());

                SqlDataReader lector2 = ADT2.ExecuteReader();
                if (lector2.Read())
                    try { uri = lector2.GetString(0); } catch { uri = "NO"; }

            }
            catch (Exception ex)
            {
                uri = "NO";
            }
            finally
            {
                CNN.Close();
            }

            return uri;

        }
        public miCorreo getCorreo()
        {
            miCorreo elcorre = new miCorreo();

            SqlConnection CNN = new SqlConnection(cadena.integrla);
            try
            {
                CNN.Open();
                SqlCommand ADT2 = new SqlCommand("SELECT email, passs, smtp, puerto, pop3, puertopop, displayname, useSls FROM mail WHERE id=3", CNN);
                SqlDataReader lector2 = ADT2.ExecuteReader();
                if (lector2.Read())
                {
                    elcorre.email = lector2.GetString(0);
                    elcorre.pas = lector2.GetString(1);
                    elcorre.hostSmtp = lector2.GetString(2);
                    elcorre.portSmtp = lector2.GetInt32(3);
                    elcorre.hostPop = lector2.GetString(4);
                    elcorre.portPop = lector2.GetInt32(5);
                    elcorre.nombre = lector2.GetString(6);
                    elcorre.useSls = lector2.GetBoolean(7);

                }


            }
            catch (Exception ex)
            {
                elcorre = null;
            }
            finally
            {
                CNN.Close();
            }
            return elcorre;
        }


        #endregion
        #region "INDICADORES"

        public int cantComunicadaC901()
        {
            int cant = 0;

            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT COUNT(PARTE901) AS cant FROM C901_UTILIZACION WHERE (FCOMU901 BETWEEN @D1 AND @D2) GROUP BY ESTCOMU901 HAVING (ESTCOMU901 = 1)", cnn);
                adt.Parameters.AddWithValue("D1", DateTime.Now.ToString("dd/MM/yyyy") + " 00:00:00");
                adt.Parameters.AddWithValue("D2", DateTime.Now.ToString("dd/MM/yyyy") + " 23:59:58");

                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        public int cantComunicadaC904()
        {
            int cant = 0;
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT COUNT(NPARTE904) AS cant FROM C904_ACOMETIDA WHERE (FCOMU904 BETWEEN @D1 AND @D2) GROUP BY ESTCOMU904 HAVING (ESTCOMU904 = 1)", cnn);
                adt.Parameters.AddWithValue("D1", DateTime.Now.ToString("dd/MM/yyyy") + " 00:00:00");
                adt.Parameters.AddWithValue("D2", DateTime.Now.ToString("dd/MM/yyyy") + " 23:59:58");

                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        public int cantErrorC901()
        {
            int cant = 0;
            SqlConnection cnn = new SqlConnection(cadena.integrla);


            try
            {

                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT COUNT(PARTE901) AS cant FROM C901_UTILIZACION WHERE (FCOMU901 BETWEEN @D1 AND @D2) GROUP BY ESTCOMU901 HAVING (ESTCOMU901 = 0)", cnn);
                adt.Parameters.AddWithValue("D1", DateTime.Now.ToString("dd/MM/yyyy") + " 00:00:00");
                adt.Parameters.AddWithValue("D2", DateTime.Now.ToString("dd/MM/yyyy") + " 23:59:58");

                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        public int cantErrorC904()
        {
            int cant = 0;
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT COUNT(NPARTE904) AS cant FROM C904_ACOMETIDA WHERE (FCOMU904 BETWEEN @D1 AND @D2) GROUP BY ESTCOMU904 HAVING (ESTCOMU904 = 0)", cnn);
                adt.Parameters.AddWithValue("D1", DateTime.Now.ToString("dd/MM/yyyy") + " 00:00:00");
                adt.Parameters.AddWithValue("D2", DateTime.Now.ToString("dd/MM/yyyy") + " 23:59:58");

                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        public int cantAcomunicarC901(DateTime fecha, int tipo)
        {
            int cant = 0;

            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand();
                if (tipo == 0)
                {
                    adt = new SqlCommand("SELECT COUNT(C901_UTILIZACION.PARTE901) AS cant FROM C901_UTILIZACION INNER JOIN C900_TAREAS ON C901_UTILIZACION.CCONT901 = C900_TAREAS.CCONT900 AND C901_UTILIZACION.TIPO_TRAB901 = C900_TAREAS.TIPO_TRAB900 AND C901_UTILIZACION.NGNF901 = C900_TAREAS.NGNF900 AND C901_UTILIZACION.PARTE901 = C900_TAREAS.NPARTE900 AND C901_UTILIZACION.FE_EMISION901 = C900_TAREAS.FE_EMISION900 WHERE (C900_TAREAS.ORGTRAB900 = N'W') AND (C901_UTILIZACION.FREALIZADO901 < @D1) AND (C901_UTILIZACION.VMED901=0) AND (C901_UTILIZACION.VPAPEL901=0) GROUP BY C901_UTILIZACION.ESTCOMU901 HAVING (C901_UTILIZACION.ESTCOMU901 IS NULL)", cnn);
                }
                else
                {
                    adt = new SqlCommand("SELECT COUNT(C901_UTILIZACION.PARTE901) AS cant FROM C901_UTILIZACION INNER JOIN C900_TAREAS ON C901_UTILIZACION.CCONT901 = C900_TAREAS.CCONT900 AND C901_UTILIZACION.TIPO_TRAB901 = C900_TAREAS.TIPO_TRAB900 AND C901_UTILIZACION.NGNF901 = C900_TAREAS.NGNF900 AND C901_UTILIZACION.PARTE901 = C900_TAREAS.NPARTE900 AND C901_UTILIZACION.FE_EMISION901 = C900_TAREAS.FE_EMISION900 WHERE (C900_TAREAS.ORGTRAB900 = N'W') AND (C901_UTILIZACION.FREALIZADO901 < @D1) GROUP BY C901_UTILIZACION.ESTCOMU901 HAVING (C901_UTILIZACION.ESTCOMU901 IS NULL)", cnn);
                }
                adt.Parameters.AddWithValue("D1", fecha);
                // adt.Parameters.AddWithValue("D1", fecha);
                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); } else { cant = 0; }

            }
            catch (Exception ex) { cant = 0; MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        public int cantAcomunicarC904(DateTime fecha)
        {
            int cant = 0;
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT COUNT(NPARTE904) AS cant FROM C904_ACOMETIDA GROUP BY ESTCOMU904 HAVING (ESTCOMU904 IS NULL)", cnn);
                SqlDataReader a = adt.ExecuteReader();
                if (a.Read()) { cant = a.GetInt32(0); } else { cant = 0; }

            }
            catch (Exception ex) { cant = 0; MessageBox.Show(ex.Message); }
            finally { cnn.Close(); }


            return cant;
        }
        #endregion
        #region"LISTA DE PARTES A COMUNICAR"
        public List<taskCom> getListC901(DateTime fecha, int tipo)
        {
            List<taskCom> dt = new List<taskCom>();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            //fecha = DateTime.Now.AddMinutes(retrasoMinuto);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand();
                //0 es sin validaciones 
                if (tipo == 0)
                {
                    adt = new SqlCommand("SELECT C901_UTILIZACION.PARTE901, C901_UTILIZACION.TIPO_TRAB901, C900_TAREAS.FE_EMISION900, C901_UTILIZACION.NGNF901, IIF(C900_TAREAS.FEGNF900 IS NULL,C900_TAREAS.FE_EMISION900,C900_TAREAS.FEGNF900) AS FE,IIF(C900_TAREAS.NRGNF900 IS NULL,C900_TAREAS.NGNF900,C900_TAREAS.NRGNF900) AS NRGNF FROM C901_UTILIZACION INNER JOIN C900_TAREAS ON C901_UTILIZACION.CCONT901 = C900_TAREAS.CCONT900 AND C901_UTILIZACION.TIPO_TRAB901 = C900_TAREAS.TIPO_TRAB900 AND C901_UTILIZACION.NGNF901 = C900_TAREAS.NGNF900 AND C901_UTILIZACION.FE_EMISION901 = C900_TAREAS.FE_EMISION900 AND C901_UTILIZACION.PARTE901 = C900_TAREAS.NPARTE900 WHERE (C900_TAREAS.ORGTRAB900 = N'W') AND (C901_UTILIZACION.FREALIZADO901 < @D1) AND (C901_UTILIZACION.ESTCOMU901 IS NULL) AND (C901_UTILIZACION.VMED901 = 0) AND (C901_UTILIZACION.VPAPEL901 = 0) ORDER BY C901_UTILIZACION.FREALIZADO901 ", cnn);
                }
                else
                {
                    adt = new SqlCommand("SELECT C901_UTILIZACION.PARTE901, C901_UTILIZACION.TIPO_TRAB901, C900_TAREAS.FE_EMISION900, C901_UTILIZACION.NGNF901, IIF(C900_TAREAS.FEGNF900 IS NULL,C900_TAREAS.FE_EMISION900,C900_TAREAS.FEGNF900) AS FE,IIF(C900_TAREAS.NRGNF900 IS NULL,C900_TAREAS.NGNF900,C900_TAREAS.NRGNF900) AS NRGNF FROM C901_UTILIZACION INNER JOIN C900_TAREAS ON C901_UTILIZACION.CCONT901 = C900_TAREAS.CCONT900 AND C901_UTILIZACION.TIPO_TRAB901 = C900_TAREAS.TIPO_TRAB900 AND C901_UTILIZACION.NGNF901 = C900_TAREAS.NGNF900 AND C901_UTILIZACION.FE_EMISION901 = C900_TAREAS.FE_EMISION900 AND C901_UTILIZACION.PARTE901 = C900_TAREAS.NPARTE900 WHERE (C900_TAREAS.ORGTRAB900 = N'W') AND (C901_UTILIZACION.FREALIZADO901 < @D1) AND (C901_UTILIZACION.ESTCOMU901 IS NULL)  ORDER BY C901_UTILIZACION.FREALIZADO901 ", cnn);
                }

                adt.Parameters.AddWithValue("D1", fecha);
                SqlDataReader lector = adt.ExecuteReader();
                while (lector.Read())
                {
                    dt.Add(new taskCom(lector.GetString(0), lector.GetString(1), lector.GetDateTime(2), lector.GetString(3), lector.GetDateTime(4), lector.GetInt32(5).ToString()));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Error en generar lista C901");
            }
            finally
            {
                cnn.Close();
            }
            return dt;

        }
        public List<taskCom> getListC904(DateTime fecha)
        {
            List<taskCom> dt = new List<taskCom>();
            SqlConnection cnn = new SqlConnection(cadena.integrla);
            //fecha = DateTime.Now.AddMinutes(retrasoMinuto);
            try
            {
                cnn.Open();
                SqlCommand adt = new SqlCommand("SELECT C904_ACOMETIDA.NPARTE904, C904_ACOMETIDA.TIPO_TRAB904, C904_ACOMETIDA.FE_EMISION904, C904_ACOMETIDA.NGNF904 FROM C904_ACOMETIDA INNER JOIN C900_TAREAS ON C904_ACOMETIDA.CCONT904 = C900_TAREAS.CCONT900 AND C904_ACOMETIDA.TIPO_TRAB904 = C900_TAREAS.TIPO_TRAB900 AND C904_ACOMETIDA.NGNF904 = C900_TAREAS.NGNF900 AND C904_ACOMETIDA.FE_EMISION904 = C900_TAREAS.FE_EMISION900 AND C904_ACOMETIDA.NPARTE904 = C900_TAREAS.NPARTE900 WHERE (C904_ACOMETIDA.ESTCOMU904 IS NULL) AND (C900_TAREAS.ORGTRAB900 = N'O') ORDER BY C904_ACOMETIDA.NPARTE904  ", cnn);
                adt.Parameters.AddWithValue("D1", fecha);
                SqlDataReader lector = adt.ExecuteReader();
                while (lector.Read())
                {
                    dt.Add(new taskCom(lector.GetString(0), lector.GetString(1), lector.GetDateTime(2), lector.GetString(3), lector.GetDateTime(2), ""));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;

        }

        #endregion
    }
}
