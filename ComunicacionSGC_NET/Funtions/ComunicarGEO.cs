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
    class ComunicarGEO
    {
        private FuncionesSQL funcSql = new FuncionesSQL();
        public string comunicarGEO_SGC(GeoSGC GEO)
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("GEO", "000");
            if (Direccion != "NO")
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
                //WebRequest request = WebRequest.Create(Direccion);
                request.Method = "post";
                request.ContentType = "application/json; charset=utf-8";
                StreamWriter osw = new StreamWriter(request.GetRequestStream());
                osw.Write(JsonConvert.SerializeObject(GEO, Formatting.Indented));
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
                catch (Exception ex)
                {
                    respuesta = ex.Message;
                }
            }
            return respuesta;
        }
    }
}
