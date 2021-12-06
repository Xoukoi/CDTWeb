using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;
using System.Net.Mail;
using System.Net;

namespace Portafo1
{
    public partial class TareasHistoricas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel2.Visible = false;
                EjecucionBLL nuev = new EjecucionBLL();
                GridView1.DataSource = nuev.listaEjecucionesTerminadas(Session["rut"].ToString());
                GridView1.DataBind();
                GridView3.DataSource = nuev.listaEjecucionesRechazadas();
                GridView3.DataBind();
                Label2.Visible = false;
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

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EjecucionBLL eje = new EjecucionBLL();
            GridView3.PageIndex = e.NewPageIndex;
            GridView3.DataSource = eje.listaEjecucionesRechazadas();
            GridView3.DataBind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Panel2.Visible = true;
            int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Values[0]);
            Application["idejecucionglobal4"] = id;
            Label88.Text = Application["idejecucionglobal4"].ToString();
            EjecucionBLL nuev = new EjecucionBLL();
            GridView3.DataSource = nuev.listaEjecucionesRechazadas();
            GridView3.DataBind();
            Label2.Visible = false;

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EjecucionBLL nuev = new EjecucionBLL();
            int idEjec = Convert.ToInt32(Application["idejecucionglobal4"]);
            string notifi = "porconfirmar";
            string rut = DropDownList1.SelectedValue;
            nuev.ReasignarTarea(idEjec, rut, notifi);
            GridView3.DataSource = nuev.listaEjecucionesRechazadas();
            GridView3.DataBind();
            Panel2.Visible = false;
            Label2.Visible = true;

            NombreProcesoBLL corree = new NombreProcesoBLL();
            string cor = corree.buscarCorreo(DropDownList1.SelectedValue);


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("controldetareas2021duoc@gmail.com", "controldetareas2021");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            string body = "  " +
" Se le ha asignado una nueva tarea   " +

"  todos los detalles en processSA.com  " +

"  " +

"  Buenas gestiones - Process S.A.    " +

"  No responder este correo ";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("controldetareas2021duoc@gmail.com", "Process S.A. - Nueva tarea asignada");
            mail.To.Add(new MailAddress(cor));
            mail.Subject = "Se le ha asignado una nueva tarea";
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtp.Send(mail);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }
    }
}