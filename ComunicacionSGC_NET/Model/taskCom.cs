using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class taskCom
    {
        public taskCom(string poliza, string tipo_trabajo, DateTime fecEmision, string nGnf, DateTime fecCliente, string nRgnf)
        {
            this.poliza = poliza;
            this.tipo_trabajo = tipo_trabajo;
            this.fecEmision = fecEmision;
            this.nGnf = nGnf;
            this.fecCliente = fecCliente;
            this.nRgnf = nRgnf;
        }

        public string poliza { get; set; }
        public string tipo_trabajo { get; set; }
        public DateTime fecEmision { get; set; }
        public string nGnf { get; set; }
        public string nRgnf { get; set; }
        public DateTime fecCliente { get; set; }
    }
}
