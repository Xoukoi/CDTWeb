using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;

namespace Portafo1
{
    public partial class TareasHistoricas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EjecucionBLL nuev = new EjecucionBLL();
                GridView1.DataSource = nuev.listaEjecucionesTerminadas(Session["rut"].ToString());
                GridView1.DataBind();
                GridView2.DataSource = nuev.listaEjecucionesRevisadas(Session["rut"].ToString());
                GridView2.DataBind();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void rowDeletingEvent8(object sender, GridViewDeleteEventArgs e)
        {
            Button1_ModalPopupExtender.Show();
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            Application["idejecucionglobal3"] = id;
            EjecucionBLL nuev = new EjecucionBLL();
            GridView1.DataSource = nuev.listaEjecucionesTerminadas(Session["rut"].ToString());
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();
            IdTareasBLL idtar = new IdTareasBLL();
            IdTareasBLL idtarr = new IdTareasBLL();


            ejecu.idEjec = Convert.ToInt32(Application["idejecucionglobal3"]);
            ejecu.notifi = "revisada";
            ejecu.fechaEjecucion = Calendar1.TodaysDate;
            EjecucionBLL nuevo = new EjecucionBLL();
            nuevo.cambiarEstadoEjecucion(ejecu);


            ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
            EstadoTarBLL estatarnuev = new EstadoTarBLL();

            estador.idestadotar = idtarr.contarEstadosTar() + 1;
            estador.estado = "aceptada";
            estador.descripcion = TextBoxcomentario.Text;
            estador.idejecu = ejecu.idEjec;
            estatarnuev.AgregarTarea(estador);

            GridView1.EditIndex = -1;
            GridView1.DataSource = null;
            GridView1.DataSource = nuevo.listaEjecucionesTerminadas(Session["rut"].ToString());
            GridView1.DataBind();

        }
    }
}