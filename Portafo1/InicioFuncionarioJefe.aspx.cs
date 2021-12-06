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
    public partial class TareasAsociadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TareaBLL tarea = new TareaBLL();

                GridView2.DataSource = tarea.listarTareasAso(Session["rut"].ToString());
                GridView2.DataBind();
                IdTareasBLL idtar = new IdTareasBLL();

                txtId.ReadOnly = false;


                PersonalBLL perso = new PersonalBLL();

                GridView7.DataSource = perso.listarPersonalAso(Session["rut"].ToString());
                GridView7.DataBind();
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int idtaree = 0;
            idtaree = int.Parse(DropDownListTareaPadr.SelectedValue);
            if (txtNombre.Text == "" || txtDesc.Text == "" || txtObse.Text == "")
            {
                Labelerrotar.Text = "Ninguno de las campos debe estar vacio";
                Labelerrotar.Visible = true;
                Button9_ModalPopupExtender.Show();
            }
            else
            {
                if (CheckBox1.Checked == true)
                {
                    System.Diagnostics.Debug.WriteLine("fue presionado el checkbox");
                    idtaree = 0;
                }

                System.Diagnostics.Debug.WriteLine(idtaree.ToString());



                IdTareasBLL idtar = new IdTareasBLL();

                ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
                tarea.IdTarea = idtar.contarTareas() + 1;
                tarea.tipoTarea = 1; 
                tarea.nombreTa = txtNombre.Text;
                tarea.descripcion = txtDesc.Text;
                tarea.observacion = txtObse.Text;
                tarea.adjudicador = Session["rut"].ToString();
                tarea.tar_idtar = idtaree;

                tarea.habilitado = "habilitado";
                tarea.idProce = idtar.buscarIdProce(DropDownListproce.SelectedValue);
                TareaBLL nuevo = new TareaBLL();

                nuevo.AgregarTarea(tarea);
                txtNombre.Text = "";
                txtDesc.Text = "";
                txtObse.Text = "";
                CheckBox1.Checked = false;
                Labelconfirtar.Text = "Tarea agregada con éxito";
                Labelconfirtar.Visible = true;
                Labelerrotar.Visible = false;
                Button9_ModalPopupExtender.Show();
            }
            

            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TareaBLL tarea = new TareaBLL();
            string rut = Convert.ToString(HttpContext.Current.Session["rut"]);
            System.Diagnostics.Debug.WriteLine(rut);
            System.Diagnostics.Debug.WriteLine(txtId.Text);
            System.Diagnostics.Debug.WriteLine(Session["rut"].ToString());

            System.Diagnostics.Debug.WriteLine(tarea.buscarTarea(int.Parse(txtId.Text), Session["rut"].ToString()).DESCRIPCION);


            txtDesc.Text = tarea.buscarTarea(int.Parse(txtId.Text), Session["rut"].ToString()).DESCRIPCION;

            txtNombre.Text = tarea.buscarTarea(int.Parse(txtId.Text), Session["rut"].ToString()).NOMBRETA;
            txtObse.Text = tarea.buscarTarea(int.Parse(txtId.Text), Session["rut"].ToString()).observacion;
            txtId.ReadOnly = true;
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListTareaPadr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                lbliderr.Text = "ingrese un id";
            }
            else
            {
                ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();

                IdTareasBLL idtar = new IdTareasBLL();

                tarea.IdTarea = int.Parse(txtId.Text);
                tarea.nombreTa = txtNombre.Text;
                tarea.descripcion = txtDesc.Text;
                tarea.observacion = txtObse.Text;

                tarea.tar_idtar = int.Parse(DropDownListTareaPadr.SelectedValue);

                tarea.idProce = idtar.buscarIdProce(DropDownListproce.SelectedValue);
                TareaBLL nuevo = new TareaBLL();
                System.Diagnostics.Debug.WriteLine(tarea.nombreTa);
                nuevo.EditarTarea(tarea);
                txtId.ReadOnly = false;
                lbliderr.Text = "";
            }

            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtId.Text=="")
            {
                lbliderr.Text = "ingrese un id";
            }
            else
            {
                ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();

                IdTareasBLL idtar = new IdTareasBLL();

                tarea.IdTarea = int.Parse(txtId.Text);
                tarea.habilitado = "deshabilitado";
                TareaBLL nuevo = new TareaBLL();
                System.Diagnostics.Debug.WriteLine(tarea.nombreTa);
                nuevo.deshabilitarTarea(tarea);
                txtId.ReadOnly = false;
                lbliderr.Text = "";
            }

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TareaBLL tarea = new TareaBLL();
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = tarea.listarTareasAso(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void roeCancelEditEvent(object sender, GridViewCancelEditEventArgs e)
        {
            TareaBLL tarea = new TareaBLL();
            GridView2.EditIndex = -1;
            GridView2.DataSource = null;
            GridView2.DataSource = tarea.listarTareasAso(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            Button6_ModalPopupExtender.Show();
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            Application["idtareaglobal"] = id;
            System.Diagnostics.Debug.WriteLine(Application["idtareaglobal"].ToString());
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            TareaBLL tareas = new TareaBLL();
            GridView2.DataSource = null;
            GridView2.DataSource = tareas.listarTareasAso(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void rowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow selecfil = GridView2.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
            string nombre = (selecfil.FindControl("TextBoxnombre") as TextBox).Text;
            string desc = (selecfil.FindControl("TextBoxDescripcion") as TextBox).Text;
            string obse = (selecfil.FindControl("TextBoxObser") as TextBox).Text;
            System.Diagnostics.Debug.WriteLine(nombre);

            ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();

            IdTareasBLL idtar = new IdTareasBLL();

            tarea.IdTarea = id;
            tarea.nombreTa = nombre;
            tarea.descripcion = desc;
            tarea.observacion = obse;
            TareaBLL nuevo = new TareaBLL();
            System.Diagnostics.Debug.WriteLine(tarea.nombreTa);
            nuevo.EditarTarea(tarea);
            txtId.ReadOnly = false;
            lbliderr.Text = "";
            TareaBLL tareas = new TareaBLL();
            GridView2.EditIndex = -1;
            GridView2.DataSource = null;
            GridView2.DataSource = tareas.listarTareasAso(Session["rut"].ToString());
            GridView2.DataBind();

        }

        protected void Button7_Click(object sender, EventArgs e)
        {

        }

        protected void Button7_Click1(object sender, EventArgs e)
        {
            ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
            IdTareasBLL idtar = new IdTareasBLL();

            tarea.IdTarea = Convert.ToInt32(Application["idtareaglobal"]);
            tarea.habilitado = "deshabilitado";
            TareaBLL nuevo = new TareaBLL();
            System.Diagnostics.Debug.WriteLine(tarea.nombreTa);
            nuevo.deshabilitarTarea(tarea);
            txtId.ReadOnly = false;
            lbliderr.Text = "";
            TareaBLL tareas = new TareaBLL();
            GridView2.EditIndex = -1;
            GridView2.DataSource = null;
            GridView2.DataSource = tareas.listarTareasAso(Session["rut"].ToString());
            GridView2.DataBind();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

        }

        protected void rowasignar(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void rowasig(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Buttonasignar_ModalPopupExtender.Show();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Buttonasignar_ModalPopupExtender.Show();
        }

        protected void Button2_Click2(object sender, EventArgs e)
        {
            int ween = 0;
            IdTareasBLL idtarr = new IdTareasBLL();
            int cantidadejecu = idtarr.contarEjecucioness() + 1;
            lblcalendarios.Visible = false;
            labeldatoono.Visible = false;
            lblexito.Visible = false;
            if (Calendar1.SelectedDate.Date >= Calendar2.TodaysDate)
            {
                if (texdescip.Text.Length > 4)
                {
                    if (Calendar1.SelectedDate.Date < Calendar2.SelectedDate.Date)
                    {

                        var dateAndTime = DateTime.Now;
                        var Date = dateAndTime.ToShortDateString();
                        ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();


                        IdTareasBLL idtar = new IdTareasBLL();

                        ejecu.idEjec = cantidadejecu;
                        ejecu.descrip = texdescip.Text; 
                        ejecu.fechaInicio = Calendar1.SelectedDate.Date;
                        ejecu.fechaTermino = Calendar2.SelectedDate.Date;
                        ejecu.fechaEjecucion = Calendar2.TodaysDate;
                        ejecu.personal_rut = DropDownList7.SelectedValue;
                        ejecu.semaforo = "Plazo";
                        ejecu.notifi = "porconfirmar";
                        ejecu.tareaId = int.Parse(DropDownList8.SelectedValue);
                        EjecucionBLL nuevo = new EjecucionBLL();

                        int carga = idtar.contarCargadeTrabajo(DropDownList7.SelectedValue);
                        int carga2 = carga + idtar.contarCargadeTrabajoasignadas(DropDownList7.SelectedValue);

                        if (carga2 >= 15)
                        {
                            ween = 0;
                            Label36.Visible = true;
                            Label36.Text = "Funcionario con el maximos de tareas asignadas";
                            Buttonasignar_ModalPopupExtender.Show();
                        }
                        else
                        {
                            nuevo.AgregarEjecucion(ejecu);
                            Label36.Visible = false;
                            lblexito.Text = "Tarea asignada correctamente";
                            lblexito.Visible = true;
                            ween = 1;

                            NombreProcesoBLL corree = new NombreProcesoBLL();
                            string cor = corree.buscarCorreo(DropDownList7.SelectedValue);

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

                            Buttonasignar_ModalPopupExtender.Show();
                        }

                }
                    else
                    {
                        lblcalendarios.Text = "La fecha de inicio no puede ser mayor o igual a la de término";
                        lblcalendarios.Visible = true;
                        ween = 0;
                        Buttonasignar_ModalPopupExtender.Show();
                    }
                }
                else
                {
                    labeldatoono.Text = "La descripción debe contar con al menos 4 letras";
                    labeldatoono.Visible = true;
                    ween = 0;
                    Buttonasignar_ModalPopupExtender.Show();
                }
            }
            else
            {
                lblcalendarios.Text = "La fecha de inicio no puede ser menor a la fecha actual";
                lblcalendarios.Visible = true;
                ween = 0;
                Buttonasignar_ModalPopupExtender.Show();
            }
            
            if (ween == 1)
            {
                ServiceReference1.EstadoTarN estador = new ServiceReference1.EstadoTarN();
                EstadoTarBLL estatarnuev = new EstadoTarBLL();


                estador.idestadotar = idtarr.contarEstadosTar() + 1;
                estador.estado = "asignada";
                estador.descripcion = "Tarea fue asignada";
                estador.idejecu = cantidadejecu;
                lblcalendarios.Visible = false;
                labeldatoono.Visible = false;

                texdescip.Text = "";
                Calendar1.SelectedDate = Calendar2.TodaysDate;
                Calendar2.SelectedDate = Calendar2.TodaysDate;

                estatarnuev.AgregarTarea(estador);
                Buttonasignar_ModalPopupExtender.Show();
            }
            

        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }

        protected void Button9_Click(object sender, EventArgs e)
        {

        }

        protected void GridView7_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                PersonalBLL perso = new PersonalBLL();
                GridView7.PageIndex = e.NewPageIndex;
                GridView7.DataSource = perso.listarPersonalAso(Session["rut"].ToString());
                GridView7.DataBind();
        }

        protected void Buttonasignar_Click(object sender, EventArgs e)
        {
            lblcalendarios.Visible = false;
            labeldatoono.Visible = false;

            texdescip.Text = "";
            Calendar1.SelectedDate = Calendar2.TodaysDate;
            Calendar2.SelectedDate = Calendar2.TodaysDate;
        }
    }
}