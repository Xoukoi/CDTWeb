using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Portafo1.Negocio;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Portafo1
{
    public partial class CrearProceso : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProcesoBLL proce = new ProcesoBLL();
                GridView1.DataSource = proce.ListarProceso();
                GridView1.DataBind();
            }
        }

        protected void GuardarProce(object sender, EventArgs e)
        {
            IdTareasBLL idpro = new IdTareasBLL();
            {
                lblcalendarios.Visible = false;
                lblcalendarios1.Visible = false;
                if (fechaI.SelectedDate.Date >= fechaT.TodaysDate)
                {
                    if (fechaI.SelectedDate.Date < fechaT.SelectedDate.Date)
                    {
                        var dateAndTime = DateTime.Now;
                        var Date = dateAndTime.ToShortDateString();

                        ServiceReference1.ProcesoN proce = new ServiceReference1.ProcesoN();

                        proce.IdProceso = idpro.contarProcesos()+1;
                        proce.Descripcion = txtdesc.Text;
                        proce.NombreProceso = txtnom.Text;
                        proce.Fechainit = fechaI.SelectedDate.Date;
                        proce.Fechater = fechaT.SelectedDate.Date;
                        proce.FechaActual = fechaT.TodaysDate;
                        proce.Estado = "habilitado";
                        proce.UnidadInt = int.Parse(txtU.Text);

                        ProcesoBLL nuevo = new ProcesoBLL();
                        nuevo.AgregarProcesoBLL(proce);
                        ProcesoBLL proces = new ProcesoBLL();
                        GridView1.DataSource = proces.ListarProceso();
                        GridView1.DataBind();

                    }
                    else
                    {
                        lblcalendarios.Text = "La fecha de inicio no puede ser mayor o igual a la de término";
                        lblcalendarios.Visible = true;
                    }
                }
                else
                {
                    lblcalendarios1.Text = "La fecha de inicio no puede ser menor que la fecha actual";
                    lblcalendarios1.Visible = true;
                }
            }

        }



        protected void BuscarProce(object sender, EventArgs e)
        {


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rowCancelEditEvent(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ProcesoBLL proce = new ProcesoBLL();
            GridView1.DataSource = proce.ListarProceso();
            GridView1.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            ServiceReference1.ProcesoN proce = new ServiceReference1.ProcesoN();
            proce.IdProceso = codigo;
            proce.Estado = "deshabilitado";
            ProcesoBLL nuevo = new ProcesoBLL();
            nuevo.EliminarProcesoBLL(proce);
            GridView1.EditIndex = -1;
            ProcesoBLL proces = new ProcesoBLL();
            GridView1.DataSource = proces.ListarProceso();
            GridView1.DataBind();

        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ProcesoBLL proces = new ProcesoBLL();
            GridView1.DataSource = proces.ListarProceso();
            GridView1.DataBind();
        }

        protected void rowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GridView1.Rows[e.RowIndex];
            int codigo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string nombre = (fila.FindControl("TextBoxNombreee") as TextBox).Text;
            string descri = (fila.FindControl("TextBoxDescrippp") as TextBox).Text;

            ProcesoBLL process = new ProcesoBLL();

            ServiceReference1.ProcesoN prooo = new ServiceReference1.ProcesoN();
            prooo.IdProceso = codigo;
            prooo.NombreProceso = nombre;
            prooo.Descripcion = descri;
            process.ModificarProcesoBLL(prooo);
            GridView1.EditIndex = -1;
            ProcesoBLL proce = new ProcesoBLL();
            GridView1.DataSource = proce.ListarProceso();
            GridView1.DataBind();
        }

        protected void fechaI_SelectionChanged(object sender, EventArgs e)
        {
            Button1_ModalPopupExtender.Show();
        }

        protected void fechaT_SelectionChanged(object sender, EventArgs e)
        {
            Button1_ModalPopupExtender.Show();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            int idtaree = 0;

            if (txtNombre.Text == "" || TextBox14.Text == "" || txtObse.Text == "")
            {
                Labelerrotar.Text = "Ninguno de las campos debe estar vacio";
                Labelerrotar.Visible = true;
                Button2_ModalPopupExtender.Show();
            }
            else
            {

                System.Diagnostics.Debug.WriteLine(idtaree.ToString());

                IdTareasBLL idtar = new IdTareasBLL();

                ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
                tarea.IdTarea = idtar.contarTareas() + 1;
                tarea.tipoTarea = 2; 
                tarea.nombreTa = txtNombre.Text;
                tarea.descripcion = TextBox14.Text;
                tarea.observacion = txtObse.Text;
                tarea.adjudicador = Session["rut"].ToString();
                tarea.tar_idtar = idtaree;

                tarea.habilitado = "habilitado";
                tarea.idProce = idtar.buscarIdProce(DropDownListproce.SelectedValue);
                TareaBLL nuevo = new TareaBLL();

                nuevo.AgregarTarea(tarea);
                txtNombre.Text = "";
                TextBox14.Text = "";
                txtObse.Text = "";
                Labelconfirtar.Text = "Tarea agregada con éxito";
                Labelconfirtar.Visible = true;
                Labelerrotar.Visible = false;
                Button2_ModalPopupExtender.Show();
            }
        }
    }
}