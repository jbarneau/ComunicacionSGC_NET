using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT11_17_47_54
    {
        //OT11/17/47/54(http://10.218.1.154:8080/gasnatural/api/ot-11-17-47-54/+ot)
        public int agenteMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public ArrayList cdVivMac { get; set; } = new ArrayList();
        public ArrayList colorMac { get; set; } = new ArrayList();
        public string confCteMac { get; set; }
        public float contrataMac { get; set; }

        public float estadoRetiMac { get; set; }
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public float hoRealizMac { get; set; }
        public string identPolExpMac { get; set; }
        public ArrayList materialMac { get; set; } = new ArrayList();
        public string nusuarioMac { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
        public int polExpMac { get; set; }
        public float resultadoMac { get; set; }
    }
}
