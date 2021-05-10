using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT36
    {
        //OT36 (http://10.218.1.154:8080/gasnatural/api/ot-36/36)
        public int agenteMac { get; set; }
        public ArrayList anexosMac { get; set; } = new ArrayList();
        public string capacColoMac { get; set; }
        public string capacRetiMac { get; set; }
        public ArrayList cdVivMac { get; set; } = new ArrayList();
        public ArrayList codRechaMac { get; set; } = new ArrayList();
        public ArrayList colorMac { get; set; } = new ArrayList();
        public string confCteMac { get; set; }
        public int contrataMac { get; set; }
        public int estadoColoMac { get; set; }
        public int estadoRetiMac { get; set; }
        public string feRealizaMac { get; set; }
        public string firmoCteMac { get; set; }
        public int hoRealizMac { get; set; }
        public string identPolExpMac { get; set; }
        public string marcaColoMac { get; set; }
        public string marcaRetiMac { get; set; }
        public ArrayList materialMac { get; set; } = new ArrayList();
        public ArrayList no2Mac { get; set; } = new ArrayList();
        public int numeroColoMac { get; set; }
        public int numeroRetiMac { get; set; }
        public string nusuarioMac { get; set; }
        public ArrayList observNuevaMac { get; set; } = new ArrayList();
        public int polExpMac { get; set; }
        public int resultadoMac { get; set; }
        public ArrayList si2Mac { get; set; } = new ArrayList();
        public int unidMedContColoMac { get; set; }
        public int unidMedContRetiMac { get; set; }

    }
}
