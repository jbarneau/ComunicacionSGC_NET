using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT03_07_10
    {
        //OT 03/07/10 (http://10.218.1.154:8080/gasnatural/api/ot-03-07-10/+OT)
        public int agenteMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public string confCteMac { get; set; }
        public string consumoEstimado { get; set; }
        public int contrataMac { get; set; }
        public string diametroAcometida { get; set; }
        public string diametroCanioMayor { get; set; }
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public int hoRealizMac { get; set; }
        public string identPolExpMac { get; set; }
        public string materialCanioMayor { get; set; }
        public string nusuarioMac { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
        public int polExpMac { get; set; }
        public int resultadoMac { get; set; }

    }
}
