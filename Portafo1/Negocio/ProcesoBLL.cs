using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class ProcesoBLL
    {
        public int IDPROCESO { get; set; }
        public string DESCRIPCION { get; set; }
        public string NOMBREPROCESO { get; set; }
        public DateTime FECHAINIT { get; set; }
        public DateTime FECHATER { get; set; }
        public DateTime FECHAACTUAL { get; set; }
        public string ESTADO { get; set; }
        public int UNIDADINT { get; set; }

        public List<ProcesoBLL> ListarProceso()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<ProcesoBLL> lista = new List<ProcesoBLL>();

            foreach (var item in wcf.ListarProceso())
            {

                ProcesoBLL otro = new ProcesoBLL();
                otro.IDPROCESO = item.IdProceso;
                otro.DESCRIPCION = item.Descripcion;
                otro.NOMBREPROCESO = item.NombreProceso;
                otro.FECHAINIT = item.Fechainit;
                otro.FECHATER = item.Fechater;
                otro.FECHAACTUAL = item.FechaActual;
                otro.ESTADO = item.Estado.ToString();
                otro.UNIDADINT = item.UnidadInt;
                lista.Add(otro);

            }
            return lista;

        }

        public void AgregarProcesoBLL(ServiceReference1.ProcesoN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            wcf.AgregarProce(item);
        }

        public void ModificarProcesoBLL(ServiceReference1.ProcesoN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            wcf.modificarProce(item);
        }

        public void EliminarProcesoBLL(ServiceReference1.ProcesoN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            wcf.eliminarrProce(item);
        }

        public ProcesoBLL buscarProceBLL(int idproceso)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ProcesoBLL otron = new ProcesoBLL();
            foreach (var item in wcf.ListarProceso())
            {
                if (item.IdProceso == idproceso)
                {
                    otron.IDPROCESO = item.IdProceso;
                    otron.DESCRIPCION = item.Descripcion;
                    otron.NOMBREPROCESO = item.NombreProceso;
                    otron.FECHAINIT = item.Fechainit;
                    otron.FECHATER = item.Fechater;
                    otron.FECHAACTUAL = item.FechaActual;
                    otron.ESTADO = item.Estado.ToString();
                    otron.UNIDADINT = item.UnidadInt;
                    return otron;
                }
            }
            return otron;
        }
    }
}
