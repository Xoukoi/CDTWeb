using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class TareaBLL : WebPageTraceListener
    {
        public int IDTAREA { get; set; }
        public int TIPOTAREA { get; set; }
        public string NOMBRETA { get; set; }
        public string DESCRIPCION { get; set; }
        public string observacion { get; set; }
        public string adjudicador { get; set; }
        public string habilitado { get; set; }
        public int TAREA_IDTAREA { get; set; }
        public int proce_idproce { get; set; }

        public string nombreProce { get; set; }


        public void AgregarTarea(ServiceReference1.TareaN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
            wcf.AgregarTar(item);
        }
        public void EditarTarea(ServiceReference1.TareaN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
            wcf.EditarTar(item);
        }
        public void deshabilitarTarea(ServiceReference1.TareaN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.TareaN tarea = new ServiceReference1.TareaN();
            wcf.deshabilitarTar(item);
        }
        public List<TareaBLL> listarTareas()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<TareaBLL> lista = new List<TareaBLL>();
            string rut = Convert.ToString(HttpContext.Current.Session["rut"]);
            System.Diagnostics.Debug.WriteLine(rut);
            foreach (var item in wcf.ListarTareaaaaaas())
            {

                TareaBLL otro = new TareaBLL();
                otro.IDTAREA = item.IdTarea;
                otro.TIPOTAREA = item.tipoTarea;
                otro.NOMBRETA = item.nombreTa;
                otro.DESCRIPCION = item.descripcion;
                otro.observacion = item.observacion;
                otro.adjudicador = item.adjudicador;
                otro.habilitado = item.habilitado;
                otro.TAREA_IDTAREA = item.tar_idtar;
                otro.nombreProce = item.proce_nomb;
                otro.proce_idproce = item.idProce;
                lista.Add(otro);

            }
            return lista;

        }



        public List<TareaBLL> listarTareasAso(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<TareaBLL> lista = new List<TareaBLL>();

            foreach (var item in wcf.ListarTareaAsociadasAUnFuncionarioJefe(rut))
            {

                TareaBLL otro = new TareaBLL();
                otro.IDTAREA = item.IdTarea;
                otro.TIPOTAREA = item.tipoTarea;
                otro.NOMBRETA = item.nombreTa;
                otro.DESCRIPCION = item.descripcion;
                otro.observacion = item.observacion;
                otro.adjudicador = item.adjudicador;
                otro.habilitado = item.habilitado;
                otro.TAREA_IDTAREA = item.tar_idtar;
                otro.nombreProce = item.proce_nomb;
                otro.proce_idproce = item.idProce;
                lista.Add(otro);

            }
            return lista;

        }

        
        public TareaBLL buscarTarea(int idtareaa, string rute)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            TareaBLL otro = new TareaBLL();
            ServiceReference1.TareaN buscaTareas = new ServiceReference1.TareaN();
            

            buscaTareas = wcf.BuscarTarea(idtareaa, rute);
            
                otro.IDTAREA = wcf.BuscarTarea(idtareaa, rute).IdTarea;
                otro.TIPOTAREA = wcf.BuscarTarea(idtareaa, rute).tipoTarea;
                otro.NOMBRETA = wcf.BuscarTarea(idtareaa, rute).nombreTa;
                otro.DESCRIPCION = wcf.BuscarTarea(idtareaa, rute).descripcion;
                otro.observacion = wcf.BuscarTarea(idtareaa, rute).observacion;
                otro.adjudicador = wcf.BuscarTarea(idtareaa, rute).adjudicador;
                otro.habilitado = wcf.BuscarTarea(idtareaa, rute).habilitado;
                otro.TAREA_IDTAREA = wcf.BuscarTarea(idtareaa, rute).tar_idtar;
                otro.nombreProce = wcf.BuscarTarea(idtareaa, rute).proce_nomb;
                

            
            return otro;

        }

    }
}







