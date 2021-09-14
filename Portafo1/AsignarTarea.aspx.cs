using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;

namespace Portafo1
{
    public partial class AsignarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["rut"].ToString() == "3")
            {
                Server.Transfer("Error.aspx");
            }
            else
            {
                TareaBLL tarea = new TareaBLL();
                GridView1.DataSource = tarea.listarTareasAso(Session["rut"].ToString());
                GridView1.DataBind();

                PersonalBLL perso = new PersonalBLL();

                GridView7.DataSource = perso.listarPersonalAso(Session["rut"].ToString());
                GridView7.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblcalendarios.Visible = false;
            labeldatoono.Visible = false;
            lblexito.Visible = false;
            if (TextBoxDescr.Text.Length > 4)
            {
                if (Calendar1.SelectedDate.Date < Calendar2.SelectedDate.Date)
                {

                    var dateAndTime = DateTime.Now;
                    var Date = dateAndTime.ToShortDateString();
                    ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();

                    IdTareasBLL idtar = new IdTareasBLL();

                    ejecu.idEjec = idtar.contarEjecuciones() + 1;
                    ejecu.descrip = TextBoxDescr.Text; 
                    ejecu.fechaInicio = Calendar1.SelectedDate.Date;
                    ejecu.fechaTermino = Calendar2.SelectedDate.Date;
                    ejecu.fechaEjecucion = Calendar2.TodaysDate;

                    ejecu.semaforo = "verde";
                    ejecu.notifi = "porconfirmar";
                    EjecucionBLL nuevo = new EjecucionBLL();

                    nuevo.AgregarEjecucion(ejecu);

                    lblexito.Text = "Tarea asignada correctamente";
                    lblexito.Visible = true;
                }
                else
                {
                    lblcalendarios.Text = "La fecha de inicio no puede ser mayor o igual a la de término";
                    lblcalendarios.Visible = true;
                }
            }
            else
            {
                labeldatoono.Text = "La descripción debe contar con al menos 4 letras";
                labeldatoono.Visible = true;
            }


            

        }

        protected void TextBoxDescr_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate.Date > Calendar2.SelectedDate.Date)
            {
                System.Diagnostics.Debug.WriteLine("el primero es mayor al segundo");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("el segundo es mayor al primero");
            }
            System.Diagnostics.Debug.WriteLine(Calendar2.TodaysDate);
        }
    }
}