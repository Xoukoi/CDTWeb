using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;

namespace Portafo1
{
    public partial class HomeDiseñador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NombreProcesoBLL nomb = new NombreProcesoBLL();

            Label1.Text = nomb.nombreDeLogeado(Session["rut"].ToString());
            Label2.Text = nomb.apellidoDeLogeado(Session["rut"].ToString());
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("You click me ..................");
            Session["rut"] = "0";
            Server.Transfer("Login.aspx");
        }

    }
}