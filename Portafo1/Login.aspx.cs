using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;
using Oracle.DataAccess.Client;

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