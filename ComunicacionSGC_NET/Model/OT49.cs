using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT49
    {
        //OT49 (http://10.218.1.154:8080/gasnatural/api/ot-49/49)
        public float agenteMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public string cepo { get; set; }
        public string confCteMac { get; set; }
        public float contrataMac { get; set; }
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public float hoRealizMac { get; set; }
        public string identPolExpMac { get; set; }
      
        
        //datos del medidor encontrado
        public string numeroColoMac { get; set; }
        public string marcaColoMac { get; set; }
        public string capacColoMac { get; set; }
        public string nusuarioMac { get; set; }
        public int unidMedContColoMac { get; set; }
        public float estadoColoMac { get; set; }
        
        
        public string observCepo { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
                public int polExpMac { get; set; }
        public float resultadoMac { get; set; }
    }
}
