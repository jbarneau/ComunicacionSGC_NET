using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class GeoExgadet
    {
        public string latitud { get; set; }
        public string longitud { get; set; }

        public string Parte { get; set; }
        public string Origen { get; set; }
        public string ncodRetorno { get; set; }
        public bool existe { get; set; } = false;

    }
}
