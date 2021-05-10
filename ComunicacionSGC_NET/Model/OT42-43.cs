using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT42_43
    {
        //OT42/43 (http://10.218.1.154:8080/gasnatural/api/ot-42-43/+OT)
        public string identPolExpMac { get; set; }//identificador P o E
        public int polExpMac { get; set; }//numero de poliza o expediente
        public int resultadoMac { get; set; } //01-realizada - 02-fallida
        public ArrayList anexosMac { get; set; } = new ArrayList(); //codigos anexos
        public ArrayList observNuevaMac { get; set; } = new ArrayList(); //observaciones 4 de 60 caracteres
        public string feRealizaMac { get; set; } // fecha de realizado
        public float hoRealizMac { get; set; }//hora de realizado
        public string firmoCteMac { get; set; }//firmo cliente SI/NO
        public string confCteMac { get; set; }//Conformidad de cliente SI/NO
        public int contrataMac { get; set; }//numero de contratista siempre 00768
        public int agenteMac { get; set; } //numero de agente en esta ot siempre 0
        //datos del medidor que se colocado
        public int numeroColoMac { get; set; } //nuemero de medidor 
        public string marcaColoMac { get; set; } //marca del medidor de almacenes
        public string capacColoMac { get; set; } // capacidd del medidor de almacenes
        public int unidMedContColoMac { get; set; }
        public int estadoColoMac { get; set; }
        // SI / NO 
        //1 - Se cambio llave --> siempre  NO
        //2 - Se modifico toma en nicho --> siempre NO
        //3 - Se encontro escape en cañeria interna --> siempre NO
        public ArrayList si2Mac { get; set; } = new ArrayList();
        public ArrayList no2Mac { get; set; } = new ArrayList();
        public ArrayList cdVivMac { get; set; } = new ArrayList();
        public ArrayList colorMac { get; set; } = new ArrayList();
        public ArrayList materialMac { get; set; } = new ArrayList();
        public string nusuarioMac { get; set; }

    }
}
