using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT33_34
    {
        //OT33-34 (http://10.218.1.154:8080/gasnatural/api/ot-33-34/+OT)
        public float agenteMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public ArrayList codRechaMac { get; set; } = new ArrayList();
        public string confCteMac { get; set; }
        public float contrataMac { get; set; }
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public float hoRealizMac { get; set; }
        public string identPolExpMac { get; set; }
        public string nusuarioMac { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
        public int polExpMac { get; set; }
        public string recolocoCambioMac { get; set; }
        public float resultadoMac { get; set; }
    }
}
