using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionSGC_NET.Model
{
    class OT37_39_40
    {
        //OT37/39/40 (http://10.218.1.154:8080/gasnatural/api/ot-37-39-40/+OT)
        public float agenteMac { get; set; }  // Agente mac es el usuario en el SGC para los operarios
        public ArrayList anexosMac { get; set; } = new ArrayList(); // lista de codigos de rechazos
        public int cantHabitantesMac { get; set; } // cantidad de habitantes
        public string capacidadMac { get; set; } = "    ";
        public ArrayList cdVivMac { get; set; } = new ArrayList(); // codigos de vivienda Tabla 646
        public ArrayList colorMac { get; set; } = new ArrayList(); // color de los relevado
        public string confCteMac { get; set; }  // SI/NO para la confoirmidad del cliente??????
        public float contrataMac { get; set; }  // numero de contratista para nosotros 00768
        public string direccionMac { get; set; } = "";// campos de domicilios encontrados no se utiliza
        public string entreCallesMac { get; set; } = "";
        public string escapeMac { get; set; } = " ";
        public float esferasMac { get; set; }
        public float estaRetiMac { get; set; }  // estado del medidor
        public float estadoMac { get; set; }
        public string feRealizaMac { get; set; } // fecha de realizado
        public string firmoCteMac { get; set; } // SI/NO para la firma del cliente
        public float hoRealizMac { get; set; } // hora de realizado
        public string identPolExpMac { get; set; } // P = Poliza / E=Expediente
        public string intensidadEscapeMac { get; set; } // intencidad de escape N7
        public string localidadMac { get; set; } = "";
        public string marcaMac { get; set; } = "";
        public ArrayList materialMac { get; set; } = new ArrayList(); // material de los cliente auesnte
        public ArrayList no2Mac { get; set; } = new ArrayList(); // si y no se marca con una X o con " "
        public float numeroMedidorMac { get; set; } = 0;
        // dato no relevado por ahora escape en pilares
        public string nusuarioMac { get; set; }  // usuario para comunicar en el SGC
        public ArrayList observNuevaMac { get; set; } = new ArrayList(); // observaciones 4 de 60 caracteres
        public string partidoMac { get; set; } = "";
        public int polExpMac { get; set; } // nuemero de poliza o expediente
        public float resultadoMac { get; set; } // resultado valores 01-realizada - 02-no realizada
        public ArrayList si2Mac { get; set; } = new ArrayList(); // si y no se marca con una X o con " "
    }
}
