using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class CadenaConexion
    {
       // private string conexionIntegral  = "Data Source=192.168.1.222;Initial Catalog=Sistema_Integral_Clon;User ID=sa;Password=Exgadetsa01";
        //private string conexionAlmacene  = "Data Source=192.168.1.222;Initial Catalog=BASE_EXGADET_CLON;User ID=sa;Password=Exgadetsa01";

        private string conexionIntegral = "Data Source=192.168.1.222;Initial Catalog=Sistema_Integral_Exgadet;User ID=sa;Password=Exgadetsa01";
        private string conexionAlmacene = "Data Source=192.168.1.222;Initial Catalog=BASE_EXGADET;User ID=sa;Password=Exgadetsa01";
        public string Almacen { get { return conexionAlmacene; } }
        public string integrla { get { return conexionIntegral; } }
    }
}
