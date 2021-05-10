using ComunicacionSGC_NET.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Funtions
{
    class ComunicarSGC
    {
        private readonly CadenaConexion cadena = new CadenaConexion();
        private FuncionesSQL funcSql = new FuncionesSQL();
        private int TiempoEspera = 5000; //son 5 segundos
        //IMPLMENTADAS
        public string comunicarOT28_SGC(OT28 ot28sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("28", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot28sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT33_34_SGC(OT33_34 ot33_34sgc, string OT)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl(OT.ToString(), "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot33_34sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT37_SGC(OT37_39_40 ot37sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("37", "001");
            if (Direccion != "NO")
            {
                try
                {

                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot37sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT39_SGC(OT37_39_40 ot39sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("39", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot39sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT40_SGC(OT37_39_40 ot40sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("40", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot40sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT45_SGC(OT45 ot45sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("45", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot45sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT46_SGC(OT46 ot46sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("46", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot46sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }
        public string comunicarOT49_SGC(OT49 ot49sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("49", "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot49sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }

        //EN PRUEBA
        public string comunicarOT42_43_SGC(OT42_43 ot42_43sgc, string OT)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl(OT.ToString(), "001");
            if (Direccion != "NO")
            {
                try
                {
                    HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                    request.Timeout = TiempoEspera;
                    request.Method = "post";
                    request.ContentType = "application/json; charset=utf-8";
                    StreamWriter osw = new StreamWriter(request.GetRequestStream());
                    osw.Write(JsonConvert.SerializeObject(ot42_43sgc, Formatting.Indented));
                    osw.Flush();
                    osw.Close();
                    try
                    {
                        HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                        respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                        oResponse.Close();
                    }
                    catch (System.Net.WebException ex)
                    {
                        if (ex.Status == WebExceptionStatus.ConnectFailure)
                        {
                            respuesta = "NC";
                        }
                        else
                        {
                            respuesta = ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    respuesta = "--";
                }
            }
            return respuesta;
        }



        //PENDIENTES
        public string comunicarOT11_SGC(OT11_17_47_54 ot11sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("11", "004");
            if (Direccion != "NO")
            {

                //WebRequest request = WebRequest.Create(Direccion);
                HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                request.Method = "post";
                request.ContentType = "application/json; charset=utf-8";
                StreamWriter osw = new StreamWriter(request.GetRequestStream());
                osw.Write(JsonConvert.SerializeObject(ot11sgc, Formatting.Indented));
                osw.Flush();
                osw.Close();
                try
                {

                    HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                    respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                    oResponse.Close();
                    //WebResponse oResponse = request.GetResponse();
                    //StreamReader osr = new StreamReader(oResponse.GetResponseStream());
                    //respuesta = osr.ReadToEnd().Trim();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        respuesta = "NC";
                    }
                    else
                    {
                        respuesta = ex.Message;
                    }
                }
            }
            return respuesta;
        }
        public string comunicarOT17_SGC(OT11_17_47_54 ot17sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("17", "004");
            if (Direccion != "NO")
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                //WebRequest request = WebRequest.Create(Direccion);
                request.Method = "post";
                request.ContentType = "application/json; charset=utf-8";
                StreamWriter osw = new StreamWriter(request.GetRequestStream());
                osw.Write(JsonConvert.SerializeObject(ot17sgc, Formatting.Indented));
                osw.Flush();
                osw.Close();
                try
                {
                    HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                    respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                    oResponse.Close();
                    // WebResponse oResponse = request.GetResponse();
                    //StreamReader osr = new StreamReader(oResponse.GetResponseStream());
                    //respuesta = osr.ReadToEnd().Trim();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        respuesta = "NC";
                    }
                    else
                    {
                        respuesta = ex.Message;
                    }
                }
            }
            return respuesta;
        }
        public string comunicarOT47_SGC(OT11_17_47_54 ot47sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("47", "001");
            if (Direccion != "NO")
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                //WebRequest request = WebRequest.Create(Direccion);
                request.Method = "post";
                request.ContentType = "application/json; charset=utf-8";
                StreamWriter osw = new StreamWriter(request.GetRequestStream());
                osw.Write(JsonConvert.SerializeObject(ot47sgc, Formatting.Indented));
                osw.Flush();
                osw.Close();
                try
                {
                    HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                    respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                    oResponse.Close();
                    //WebResponse oResponse = request.GetResponse();
                    //StreamReader osr = new StreamReader(oResponse.GetResponseStream());
                    //respuesta = osr.ReadToEnd().Trim();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        respuesta = "NC";
                    }
                    else
                    {
                        respuesta = ex.Message;
                    }
                }
            }
            return respuesta;
        }
        public string comunicarOT54_SGC(OT11_17_47_54 ot54sgc)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("54", "004");
            if (Direccion != "NO")
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                //WebRequest request = WebRequest.Create(Direccion);
                request.Method = "post";
                request.ContentType = "application/json; charset=utf-8";
                StreamWriter osw = new StreamWriter(request.GetRequestStream());
                osw.Write(JsonConvert.SerializeObject(ot54sgc, Formatting.Indented));
                osw.Flush();
                osw.Close();
                try
                {
                    HttpWebResponse oResponse = (HttpWebResponse)request.GetResponse();
                    respuesta = new StreamReader(oResponse.GetResponseStream()).ReadToEnd().Trim();
                    oResponse.Close();
                    //WebResponse oResponse = request.GetResponse();
                    //StreamReader osr = new StreamReader(oResponse.GetResponseStream());
                    //respuesta = osr.ReadToEnd().Trim();
                }
                catch (System.Net.WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        respuesta = "NC";
                    }
                    else
                    {
                        respuesta = ex.Message;
                    }
                }
            }
            return respuesta;
        }

    }
}
