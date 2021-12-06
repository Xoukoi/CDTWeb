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
    public partial class ReporteFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(Application["acep"]);
            int b = Convert.ToInt32(Application["recha"]);

            String[] series = { "Aceptadas", "Rechazadas" };
            int[] puntos = { a, b};

            Chart1.Palette = ChartColorPalette.Pastel;

            Chart1.Titles.Add("Tareas");

            for (int i = 0; i < series.Length; i++)
            {
                Series serie = Chart1.Series.Add(series[i]);

                serie.Label = puntos[i].ToString();

                serie.Points.Add(puntos[i]);

            }

            string rute = Application["ReRutAcep"].ToString();
            int anoo = int.Parse(Application["ano"].ToString());
            int mess = int.Parse(Application["mes"].ToString());
            EjecucionBLL nuev = new EjecucionBLL();
            GridView1.DataSource = nuev.listaEjecucionesAceptadas(rute);
            GridView1.DataBind();


        }

        public override void
   VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string attach = "attachment; filename=prueba.pdf";
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