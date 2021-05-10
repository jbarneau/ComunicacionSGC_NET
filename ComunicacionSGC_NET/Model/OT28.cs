using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT28
    {
        //OT28(http://10.218.1.154:8080/gasnatural/api/ot-28/28)
        public string identPolExpMac { get; set; }
        public int polExpMac { get; set; }
        public float agenteMac { get; set; }
        public string confCteMac { get; set; }
        public float contrataMac { get; set; }
        public string nusuarioMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public ArrayList cantidadMac { get; set; } = new ArrayList();
        public ArrayList clausuroArtefMac { get; set; } = new ArrayList();
        public ArrayList codRechaMac { get; set; } = new ArrayList();
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public float hoRealizMac { get; set; }
        public string instaloMedMac { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
        public float resultadoMac { get; set; }
        public ArrayList tipoArtefMac { get; set; } = new ArrayList();
        public ArrayList ubicArtefMac { get; set; } = new ArrayList();
        public ArrayList usoArtefMac { get; set; } = new ArrayList();
    }
}
