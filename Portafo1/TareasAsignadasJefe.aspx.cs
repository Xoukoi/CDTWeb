using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;

namespace Portafo1
{
    public partial class TareasAsignadasJefe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EjecucionBLL nuev = new EjecucionBLL();
                GridView1.DataSource = nuev.listaEjecucionesPorConfirmar(Session["rut"].ToString());
                GridView1.DataBind();
                GridView2.DataSource = nuev.listaEjecucionesAceptadas(Session["rut"].ToString());
                GridView2.DataBind();
                string colorrr = "green";
            }
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            Button1_ModalPopupExtender.Show();
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            Application["idejecucionglobal"] = id;
            EjecucionBLL nuev = new EjecucionBLL();
            GridView2.DataSource = nuev.listaEjecucionesAceptadas(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EjecucionBLL nuev = new EjecucionBLL();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = nuev.listaEjecucionesPorConfirmar(Session["rut"].ToString());
            GridView1.DataBind();
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();
            IdTareasBLL idtar = new IdTareasBLL();
            IdTareasBLL idtarr = new IdTareasBLL();


            ejecu.idEjec = Convert.ToInt32(Application["idejecucionglobal"]);
            ejecu.notifi = "aceptada";
            ejecu.fechaEjecucion = Calendar1.TodaysDate;
            EjecucionBLL nuevo = new EjecucionBLL();
            nuevo.cambiarEstadoEjecucion(ejecu);

            ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
            EstadoTarBLL estatarnuev = new EstadoTarBLL();

            estador.idestadotar = idtarr.contarEstadosTar() + 1;
            estador.estado = "aceptada";
            estador.descripcion = "aceptada";
            estador.idejecu = ejecu.idEjec;

            TextBoxrazonrechazo.Text = "";


            estatarnuev.AgregarTarea(estador);
            int num;
            GridView1.EditIndex = -1;
            GridView1.DataSource = null;
            GridView1.DataSource = nuevo.listaEjecucionesPorConfirmar(Session["rut"].ToString());
            GridView1.DataBind();
            
            GridView2.DataSource = nuevo.listaEjecucionesAceptadas(Session["rut"].ToString());

            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();
            IdTareasBLL idtar = new IdTareasBLL();
            IdTareasBLL idtarr = new IdTareasBLL();
            EjecucionBLL nuevo = new EjecucionBLL();
            if (TextBoxrazonrechazo.Text != "")
            {


                ejecu.idEjec = Convert.ToInt32(Application["idejecucionglobal"]);
                ejecu.notifi = "rechazada";

                nuevo.cambiarEstadoEjecucion(ejecu);

                ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
                EstadoTarBLL estatarnuev = new EstadoTarBLL();

                estador.idestadotar = idtarr.contarEstadosTar() + 1;
                estador.estado = "rechazada";
                estador.descripcion = TextBoxrazonrechazo.Text;
                estador.idejecu = ejecu.idEjec;
                TextBoxrazonrechazo.Text = "";

                estatarnuev.AgregarTarea(estador);

                GridView1.EditIndex = -1;
                GridView1.DataSource = null;
                GridView1.DataSource = nuevo.listaEjecucionesPorConfirmar(Session["rut"].ToString());
                GridView1.DataBind();
            }
            else
            {
                Label11.Text = "Debe ingresar el motivo del rechazo";
                GridView1.EditIndex = -1;
                GridView1.DataSource = null;
                GridView1.DataSource = nuevo.listaEjecucionesPorConfirmar(Session["rut"].ToString());
                GridView1.DataBind();
                Button1_ModalPopupExtender.Show();
            }
            
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EjecucionBLL nuev = new EjecucionBLL();
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = nuev.listaEjecucionesAceptadas(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void rowDeletingEvent2(object sender, GridViewDeleteEventArgs e)
        {
            Button2_ModalPopupExtender.Show();
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            Application["idejecucionglobal2"] = id;
            System.Diagnostics.Debug.WriteLine(Application["idejecucionglobal2"].ToString());
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();
            IdTareasBLL idtar = new IdTareasBLL();
            IdTareasBLL idtarr = new IdTareasBLL();
            EjecucionBLL nuevo = new EjecucionBLL();

            if(DropDownList1.SelectedValue == "Terminada")
            {
                if (TextBoxcomentario.Text != "")
                {

                    ejecu.idEjec = Convert.ToInt32(Application["idejecucionglobal2"]);
                    ejecu.notifi = "terminada";
                    ejecu.fechaEjecucion = Calendar1.TodaysDate;
                    nuevo.cambiarEstadoEjecucion(ejecu);

                    ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
                    EstadoTarBLL estatarnuev = new EstadoTarBLL();

                    estador.idestadotar = idtarr.contarEstadosTar() + 1;
                    estador.estado = "terminada";
                    estador.descripcion = TextBoxcomentario.Text;
                    estador.idejecu = ejecu.idEjec;

                    estatarnuev.AgregarTarea(estador);
                    Label301.Text = "";

                    GridView2.EditIndex = -1;
                    GridView2.DataSource = null;
                    GridView2.DataSource = nuevo.listaEjecucionesAceptadas(Session["rut"].ToString());
                    GridView2.DataBind();
                }
                else
                {
                    Label301.Text = "Debe ingresar un comentario";
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = null;
                    GridView1.DataSource = nuevo.listaEjecucionesPorConfirmar(Session["rut"].ToString());
                    GridView1.DataBind();
                    Button2_ModalPopupExtender.Show();
                }

            }
            else if (DropDownList1.SelectedValue == "Problema")
            {
                if (TextBoxcomentario.Text != "")
                {

                    ejecu.idEjec = Convert.ToInt32(Application["idejecucionglobal2"]);
                    ejecu.notifi = "aceptada";

                    nuevo.cambiarEstadoEjecucion(ejecu);

                    ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
                    EstadoTarBLL estatarnuev = new EstadoTarBLL();

                    estador.idestadotar = idtarr.contarEstadosTar() + 1;
                    estador.estado = "problema";
                    estador.descripcion = TextBoxcomentario.Text;
                    estador.idejecu = ejecu.idEjec;

                    estatarnuev.AgregarTarea(estador);
                    Label301.Text = "";

                    GridView2.EditIndex = -1;
                    GridView2.DataSource = null;
                    GridView2.DataSource = nuevo.listaEjecucionesAceptadas(Session["rut"].ToString());
                    GridView2.DataBind();
                }
                else
                {
                    Label301.Text = "Debe ingresar un comentario";
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = null;
                    GridView1.DataSource = nuevo.listaEjecucionesPorConfirmar(Session["rut"].ToString());
                    GridView1.DataBind();
                    Button2_ModalPopupExtender.Show();
                }

            }
            GridView2.EditIndex = -1;
            GridView2.DataSource = null;
            GridView2.DataSource = nuevo.listaEjecucionesAceptadas(Session["rut"].ToString());
            GridView2.DataBind();
        }
    }
}