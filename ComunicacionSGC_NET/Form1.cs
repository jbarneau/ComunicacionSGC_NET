using ComunicacionSGC_NET.Funtions;
using ComunicacionSGC_NET.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComunicacionSGC_NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int maxTiempo = 5;// cada treinta segundos
        private int tiempo = 0;
        private int tipo = 0; //0= CON VALIDACIONES || 1= SIN VALIDACIONES
        private float retrasoMinuto = -5;
        private int cantComunicar;
        private int cantConError = 0;
        private int cantSinError = 0;
        private FuncionesSQL funcSql = new FuncionesSQL();
        private DateTime fecha;

        #region "COMUNICACION"
        public string probarConexion()
        {
            string respuesta = "";
            string Direccion = funcSql.getUrl("P", "000");
            string fichero = @"C:\LOGCOMUNICACION\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
          
            
            File.AppendAllText(fichero + "ProbarConexion.txt","\n URL: "+ Direccion );
            HttpWebRequest request = HttpWebRequest.CreateHttp(Direccion);
            request.Timeout = 5000;
            // WebRequest request = WebRequest.Create(Direccion);

            try
            {

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();
                respuesta = "OK";
                myHttpWebResponse.Close();
            }
            catch (WebException ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }
        private void comunicarUtilizacion()
        {
            List<taskCom> lista = new List<taskCom>();
            lista = funcSql.getListC901(fecha, tipo);
            FuncionesComunicar SGC = new FuncionesComunicar();
            string mensaje = "";
            string separador = "\n###############################################################\n";
            string fichero = @"C:\LOGCOMUNICACION\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
            string archivo = "";
            if (Directory.Exists(fichero) == false)
            {
                Directory.CreateDirectory(fichero);
            }


            if (lista.Count() != 0)
            {

                foreach (var v in lista)
                {

                    switch (v.tipo_trabajo)
                    {

                        case "28":
                            mensaje = separador + SGC.Com28(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_28.txt", mensaje);
                            break;
                        case "33":
                            mensaje = separador + SGC.Com33_34(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), v.tipo_trabajo.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_33.txt", mensaje);
                            break;
                        case "34":
                            mensaje = separador + SGC.Com33_34(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), v.tipo_trabajo.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_34.txt", mensaje);
                            break;
                        case "36":
                            //mensaje =  separador +SGC.Com36(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            // File.AppendAllText(fichero + "OT_36.txt", mensaje);
                            break;
                        case "37":
                            mensaje = separador + SGC.Com37(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_37.txt", mensaje);
                            break;
                        case "39":
                            mensaje = separador + SGC.Com39(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_39.txt", mensaje);
                            break;
                        case "40":
                            mensaje = separador + SGC.Com40(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_40.txt", mensaje);
                            break;
                        case "41":
                            //mensaje = separador+ SGC.Com41(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente,v.nRgnf);
                            //  File.AppendAllText(fichero + "OT_41.txt", mensaje);
                            break;
                        case "42":
                           mensaje = separador + SGC.Com42_43(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), v.tipo_trabajo.ToString(), (DateTime)v.fecCliente,v.nRgnf);
                             File.AppendAllText(fichero + "OT_42.txt", mensaje);
                            break;
                        case "43":
                           mensaje = separador + SGC.Com42_43(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), v.tipo_trabajo.ToString(), (DateTime)v.fecCliente,v.nRgnf);
                            File.AppendAllText(fichero + "OT_43.txt", mensaje);
                            break;
                        case "45":
                            mensaje = separador + SGC.Com45(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_45.txt", mensaje);
                            break;
                        case "46":
                            mensaje = separador + SGC.Com46(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_46.txt", mensaje);
                            break;
                        case "47":
                            // mensaje =  separador + SGC.Com47(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            //File.AppendAllText(fichero + "OT_47.txt", mensaje);
                            break;
                        case "49":
                            mensaje = separador + SGC.Com49(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            File.AppendAllText(fichero + "OT_49.txt", mensaje);
                            break;
                        case "76":
                            // mensaje = separador + SGC.Com76(v.poliza.ToString(), (DateTime)v.fecEmision, v.nGnf.ToString(), (DateTime)v.fecCliente, v.nRgnf);
                            //File.AppendAllText(fichero + "OT_76.txt", mensaje);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        private void comunicaAcometida()
        {

            List<taskCom> lista = new List<taskCom>();
            lista = funcSql.getListC904(fecha);
            FuncionesComunicar SGC = new FuncionesComunicar();
            foreach (var v in lista)
            {
                switch (v.tipo_trabajo)
                {
                    case "03":
                        //SGC.Com28(dt.Rows[i][0].ToString(), (DateTime)dt.Rows[i][2], dt.Rows[i][3].ToString());
                        break;
                    case "07":
                        //SGC.Com33_34(dt.Rows[i][0].ToString(), (DateTime)dt.Rows[i][2], dt.Rows[i][3].ToString(), dt.Rows[i][1].ToString());
                        break;
                    case "11":
                        //  SGC.Com11(v.poliza, (DateTime)v.fecEmision, v.nGnf, (DateTime)v.fecCliente,"");
                        break;
                    case "17":
                        // SGC.Com17(v.poliza, (DateTime)v.fecEmision, v.nGnf, (DateTime)v.fecCliente,"");
                        break;
                    case "54":
                        //  SGC.Com54(v.poliza, (DateTime)v.fecEmision, v.nGnf, (DateTime)v.fecCliente,"");
                        break;
                    default:
                        break;

                }
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo + 1;
            if (tiempo == maxTiempo)
            {

                fecha = DateTime.Now.AddMinutes(retrasoMinuto);
                timerProceso.Stop();
                tiempo = 0;
                cantComunicar = funcSql.cantAcomunicarC901(fecha, tipo);// + cantAcomunicarC904();
                lbComunicar.Text = cantComunicar.ToString();
                if (cantComunicar != 0)
                {
                    string fichero = @"C:\LOGCOMUNICACION\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
                    tiempo = 0;
                    if (Directory.Exists(fichero) == false)
                    {
                        Directory.CreateDirectory(fichero);
                    }

                    fichero = fichero + "ProbarConexion.txt";
                    File.AppendAllText(fichero, "\n#################### " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " ####################");
                    File.AppendAllText(fichero, "\n *** TAREAS A COMUNICAR: " + cantComunicar.ToString() + " ***");

                    string mensaje = probarConexion();
                    File.AppendAllText(fichero, "\n *** PROBANDO CONEXION  ***\n *** RESULTADO: " + mensaje + " ***");
                    File.AppendAllText(fichero, "\n --------------------------------------------------");
                   // mensaje = "OK";
                    if (mensaje == "OK")
                    {
                        timerProceso.Stop();
                        comunicarUtilizacion();
                        // comunicarC904();
                        cantConError = funcSql.cantErrorC901();// + cantErrorC904();
                        lbError.Text = cantConError.ToString();
                        cantSinError = funcSql.cantComunicadaC901();// + cantComunicadaC904();
                        lbComunicadas.Text = cantSinError.ToString();
                        pendComunicarTool.Text = "PENDIENTE: " + cantComunicar.ToString();
                        comunicadasTool.Text = "COMUNICADAS:" + cantSinError.ToString();
                        conErrorTool.Text = "CON ERRO: " + cantConError.ToString();
                        tiempo = 0;
                        timerProceso.Start();
                    }
                    else
                    {
                        timerProceso.Stop();
                        //string fichero = @"C:\LOGCOMUNICACION\" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"; tiempo = 0;
                        File.AppendAllText(fichero, "\n **** NO SE PUEDE CONECTAR *****");
                        //   ENVIAR_MAIL(mensaje);
                        File.AppendAllText(fichero, "\n##################################################");
                        timerProceso.Start();
                    }

                }
                else
                {
                    timerProceso.Stop();
                    tiempo = 0;
                    timerProceso.Start();
                }
            }
            button1.Text = tiempo.ToString();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (timerProceso.Enabled == true)
            {
                timerProceso.Stop();

                tiempo = 0;
            }
            else
            {
                maxTiempo = int.Parse(nd1.Value.ToString());
                retrasoMinuto = -int.Parse(ndw2.Value.ToString());

                button1.Text = "";
                tiempo = 0;
                timerProceso.Start();

            }
        }
        public void ENVIAR_MAIL(string lista)
        {

            string fichero = @"C:\LOGCOMUNICACION\" + DateTime.Now.ToString("dd-MM-yyyy") + @"\";
            if (Directory.Exists(fichero) == false)
            {
                Directory.CreateDirectory(fichero);
            }
            fichero = fichero + "error.txt";
            tiempo = 0;
            File.AppendAllText(fichero, "\n **** ENVIANDO CORREO *****");
            MailMessage miMensage = new MailMessage();
            SmtpClient miSmtp = new SmtpClient();
            miCorreo mymail = new miCorreo();
            mymail = funcSql.getCorreo();
            miSmtp.Credentials = new System.Net.NetworkCredential(mymail.email, mymail.pas);
            miSmtp.Host = mymail.hostSmtp;
            miSmtp.Port = mymail.portSmtp;
            miSmtp.EnableSsl = false;
            miMensage.To.Add("control@exgadetsa.com.ar");
            miMensage.From = new System.Net.Mail.MailAddress(mymail.email, mymail.nombre, System.Text.Encoding.UTF8);
            miMensage.Subject = "Error en proceso de enviar a SGC " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            miMensage.SubjectEncoding = System.Text.Encoding.UTF8;
            miMensage.Body = lista.ToString();
            miMensage.BodyEncoding = System.Text.Encoding.UTF8;
            miMensage.Priority = System.Net.Mail.MailPriority.High;
            miMensage.IsBodyHtml = true;
            try
            {
                miSmtp.Send(miMensage);
                File.AppendAllText(fichero, "\n **** CORREO ENVIADO *****");
            }
            catch (Exception ex)
            {
                File.AppendAllText(fichero, "\n **** FALLO ENVIO DE CORREO *****");
                File.AppendAllText(fichero, "\n " + ex.Message);
                File.AppendAllText(fichero, "\n **** ******************* *****");

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            maxTiempo = int.Parse(nd1.Value.ToString());
            retrasoMinuto = -int.Parse(ndw2.Value.ToString());
            fecha = DateTime.Now.AddMinutes(retrasoMinuto);
            cantComunicar = funcSql.cantAcomunicarC901(fecha, tipo);// + cantAcomunicarC904();
            lbComunicar.Text = cantComunicar.ToString();
            cantConError = funcSql.cantErrorC901();// + cantErrorC904();
            lbError.Text = cantConError.ToString();
            cantSinError = funcSql.cantComunicadaC901();// + cantComunicadaC904();
            lbComunicadas.Text = cantSinError.ToString();
            pendComunicarTool.Text = "PENDIENTE: " + cantComunicar.ToString();
            comunicadasTool.Text = "COMUNICADAS:" + cantSinError.ToString();
            conErrorTool.Text = "CON ERRO: " + cantConError.ToString();
        }


        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Tu formulario esta minimizado";
                notifyIcon1.ShowBalloonTip(1000);
                cantComunicar = funcSql.cantAcomunicarC901(fecha, tipo);// + cantAcomunicarC904();
                cantConError = funcSql.cantErrorC901();// + cantErrorC904();
                cantSinError = funcSql.cantComunicadaC901();// + cantComunicadaC904();
                pendComunicarTool.Text = "PENDIENTE: " + cantComunicar.ToString();
                comunicadasTool.Text = "COMUNICADAS:" + cantSinError.ToString();
                conErrorTool.Text = "CON ERRO: " + cantConError.ToString();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ndw2_ValueChanged(object sender, EventArgs e)
        {
            maxTiempo = int.Parse(nd1.Value.ToString());
            retrasoMinuto = -int.Parse(ndw2.Value.ToString());

            cantComunicar = funcSql.cantAcomunicarC901(fecha, tipo);// + cantAcomunicarC904();
            lbComunicar.Text = cantComunicar.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}

