using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;
using Oracle.DataAccess.Client;
using System.Net.Mail;
using System.Net;

namespace Portafo1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        OracleConnection conexion = new OracleConnection("DATA SOURCE = localhost ; PASSWORD = duoc4 ; USER ID = duoc4");
        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime thisDay = DateTime.Today;
            DateTime thisDays = DateTime.Today;

            TimeSpan difFechas = thisDay - thisDays;
            int sed = difFechas.Days;
            System.Diagnostics.Debug.WriteLine("aqui taaaa");
            System.Diagnostics.Debug.WriteLine(sed);
            System.Diagnostics.Debug.WriteLine("yyyyyyy");

            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM PERSONAL WHERE RUT = :rute AND CONTRASENIA = :pass", conexion);

            comando.Parameters.Add(":rute", TextBox1.Text);
            comando.Parameters.Add(":pass", TextBox2.Text);
            OracleDataReader lector = comando.ExecuteReader();

            PersonalBLL per = new PersonalBLL();

            Application["rut"] = "3";
            Session["funcionario"] = 0;
            Session["rut"] = TextBox1.Text;
            if (lector.Read())
            {
                if (lector["ROL_IDROL"].ToString()=="1")
                {

                    EjecucionBLL ejecu = new EjecucionBLL();

                    int atra = ejecu.tareasAtrasadas(TextBox1.Text);

                    if (atra > 0)
                    {
                        NombreProcesoBLL corree = new NombreProcesoBLL();
                        string cor = corree.buscarCorreo(TextBox1.Text);

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("controldetareas2021duoc@gmail.com", "controldetareas2021");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;


                        string body = "   " +
                                " Tiene tareas atrasadas   " +

                                "Todos los detalles en www.processSA.com   " +

                                "    " +

                                "    Buenas gestiones - Process S.A.   " +
                                  
                                "    ";


                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("controldetareas2021duoc@gmail.com", "Process S.A. - Tarea atrasada");
                        mail.To.Add(new MailAddress(cor));
                        mail.Subject = "Tiene tareas atrasadas";
                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        smtp.Send(mail);

                    }


                    Session["funcionario"] = 1;
                    
                    System.Diagnostics.Debug.WriteLine(Session["funcionario"]);
                    System.Diagnostics.Debug.WriteLine(Session["rol"]);
                    Server.Transfer("TareasAsignadasJefe.aspx");
                    conexion.Close();
                    System.Diagnostics.Debug.WriteLine("You click me ..................");
                    System.Diagnostics.Debug.WriteLine("SomeText");
                    Console.WriteLine("hola.");
                    Application["rut"] = "9";

                }
                if(lector["ROL_IDROL"].ToString() == "3")
                {


                    EjecucionBLL ejecu = new EjecucionBLL();

                    int atra = ejecu.tareasAtrasadas(TextBox1.Text);

                    if (atra > 0)
                    {
                        NombreProcesoBLL corree = new NombreProcesoBLL();
                        string cor = corree.buscarCorreo(TextBox1.Text);

                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("controldetareas2021duoc@gmail.com", "controldetareas2021");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;


                        string body = "  " +
                                " Tiene tareas atrasadas  " +

                                "Todos los detalles en www.processSA.com    " +

                                "  " +

                                "Buenas gestiones - Process S.A." +

                                "";


                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("controldetareas2021duoc@gmail.com", "Process S.A. - Tarea atrasada");
                        mail.To.Add(new MailAddress(cor));
                        mail.Subject = "Tiene tareas atrasadas";
                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        smtp.Send(mail);

                    }



                    Session["funcionario"] = 3;
                    Server.Transfer("TareasAsignadasJefe.aspx");
                    conexion.Close();
                    Application["rut"] = "7";
                }
                else
                {
                    Session["funcionario"] = lector["ROL_IDROL"];
                    Session["rol"] = 2;
                    System.Diagnostics.Debug.WriteLine(Session["funcionario"]);
                    System.Diagnostics.Debug.WriteLine(Session["rol"]);
                    Server.Transfer("CrearProceso.aspx");
                    conexion.Close();
                    System.Diagnostics.Debug.WriteLine("You c...");
                    Application["rut"] = "8";
                }

            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged1(object sender, EventArgs e)
        {
            
        }
    }
}