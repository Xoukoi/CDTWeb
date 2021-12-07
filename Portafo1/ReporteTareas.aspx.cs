using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portafo1.Negocio;

namespace Portafo1
{
    public partial class ReporteTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonalBLL perso = new PersonalBLL();

            GridView7.DataSource = perso.listarPersonalAso(Session["rut"].ToString());
            GridView7.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            IdTareasBLL cont = new IdTareasBLL();
            NombreProcesoBLL nom = new NombreProcesoBLL();

            string rut = DropDownList7.SelectedValue;
            int ano = int.Parse(DropDownList9.SelectedValue);
            int mes = int.Parse(DropDownList8.SelectedValue);

            Application["rutrepo"] = rut;
            Application["anorepo"] = ano;
            Application["mesrepo"] = mes;

            int loq = cont.contarTareasAceptadas(rut, ano, mes);
            int loq2 = cont.contarTareasRechazadas(rut, ano, mes);

            int ati = cont.contarTareasAtiempo(rut);
            int atra = cont.contarTareasAtrasadas(rut);

            string nombre = nom.nombreDeLogeado(rut);
            string apellido = nom.apellidoDeLogeado(rut);
            string correo = nom.buscarCorreo(rut);

            Application["ati"] = ati;
            Application["atra"] = atra;

            Application["acep"] = loq;
            Application["recha"] = loq2;

            Application["ReRutAcep"] = rut;
            Application["repoNombre"] = nombre;

            Application["repoApellido"] = apellido;
            Application["repoCorreo"] = correo;


            Server.Transfer("TareasPorFuncionario.aspx");
        }
    }
}