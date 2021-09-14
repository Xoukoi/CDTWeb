using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;


namespace Portafo1
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NombreProcesoBLL nomb = new NombreProcesoBLL();

            
            
            Label1.Text = nomb.nombreDeLogeado(Session["rut"].ToString());
            Label2.Text = nomb.apellidoDeLogeado(Session["rut"].ToString());
            if (Convert.ToInt32(Session["funcionario"]) == 1)
            {
                Panel99.Visible = false;
                Panel4.Visible = false;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("You click me ..................");
            Session["rut"] = "0";
            Server.Transfer("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}