using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Portafo1.Negocio;
using System.Web.UI.DataVisualization.Charting;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using Rotativa;

namespace Portafo1
{
    public partial class TareasPorFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ano = Convert.ToInt32(Application["anorepo"]);
            int mes = Convert.ToInt32(Application["mesrepo"]);
            string rut = Application["rutrepo"].ToString();
            System.Diagnostics.Debug.WriteLine(mes);
            System.Diagnostics.Debug.WriteLine(ano);
            System.Diagnostics.Debug.WriteLine(rut);

            EjecucionBLL nuev = new EjecucionBLL();
            GridView1.DataSource = nuev.ReporteFinal(rut, ano, mes);
            GridView1.DataBind();
            //Application["ati"] = ati;
            //Application["atra"] = atra;

            //Application["acep"] = loq;
            //Application["recha"] = loq2;

            //Application["ReRutAcep"] = rut;
            //Application["repoNombre"] = nombre;

            //Application["repoApellido"] = apellido;
            //Application["repoCorreo"] = correo;
            //Application["anorepo"] = 0;
            //Application["mesrepo"] = 0;

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
        public string apellido()
        {
            return Application["repoApellido"].ToString();
        }
        public string correo()
        {
            return Application["repoCorreo"].ToString();
        }
        public string rut()
        {
            return Application["ReRutAcep"].ToString();
        }
        public int ano()
        {
            int acep = Convert.ToInt32(Application["anorepo"]);
            return acep;
        }
        public string hora()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        public string dia()
        {
            return DateTime.Now.ToString("dd-MM-yyyy");
        }

        
        public int mes()
        {
            int acep = Convert.ToInt32(Application["mesrepo"]);
            return acep;
        }
        public int obtener()
        {
            int acep = Convert.ToInt32( Application["acep"]);
            return acep;
        }
        public int obtener2()
        {
            int acep = Convert.ToInt32(Application["recha"]);
            return acep;
        }
        public int obtener3()
        {
            int acep = Convert.ToInt32(Application["ati"]);
            return acep;
        }
        public int obtener4()
        {
            int acep = Convert.ToInt32(Application["atra"]);
            return acep;
        }
        public string nombre()
        {
            return Application["repoNombre"].ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //EjecucionBLL nuev = new EjecucionBLL();
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataSource = nuev.listaEjecucionesPorConfirmar(Session["rut"].ToString());
            //GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string attach = "attachment; filename=Reporte-"+ Application["repoNombre"].ToString()+"-"+ Application["repoApellido"].ToString()+".pdf";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "aplication/pdf";

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            descargarPDF.RenderControl(hw);

            Document pdfDoc = new Document(PageSize.A4, 30f, 10f, 5f, 10f);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            StringReader sr = new StringReader(sw.ToString());
            HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
            htmlParser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();
        }
    }
}