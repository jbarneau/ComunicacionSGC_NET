using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class miCorreo
    {
        public string email { get; set; }
        public string pas { get; set; }
        public int portPop { get; set; }
        public int portSmtp { get; set; }
        public string hostPop { get; set; }
        public string hostSmtp { get; set; }
        public bool useSls { get; set; } = false;
        public string nombre { get; set; }

    }
}
