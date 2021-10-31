using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class NombreProcesoBLL
    {
        public string nombre { get; set; }

        public NombreProcesoBLL()
        {
        }

        public List<NombreProcesoBLL> listarNombresProceso()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<NombreProcesoBLL> lista = new List<NombreProcesoBLL>();

            foreach (var item in wcf.BuscarNombresProcesos())
            {

                NombreProcesoBLL otro = new NombreProcesoBLL();
                otro.nombre = item.Nombre;
                lista.Add(otro);

            }
            return lista;

        }
        public List<NombreProcesoBLL> listarRutsAso(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<NombreProcesoBLL> lista = new List<NombreProcesoBLL>();

            foreach (var item in wcf.ListarRutsAsociadosAUnjefe(rut))
            {

                NombreProcesoBLL otro = new NombreProcesoBLL();
                otro.nombre = item.Nombre;
                lista.Add(otro);

            }
            return lista;

        }
        public string nombreDeLogeado(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            string nombre ="x";

            foreach (var item in wcf.MostrarNombrePer(rut))
            {


                nombre = item.Nombre;
                

            }
            return nombre;

        }
        public string buscarCorreo(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            string nombre = "x";

            foreach (var item in wcf.BuscarCorreo(rut))
            {


                nombre = item.Nombre;


            }
            return nombre;

        }
        public string apellidoDeLogeado(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            string apellido = "x";

            foreach (var item in wcf.MostrarApelloi(rut))
            {


                apellido = item.Nombre;


            }
            return apellido;

        }

    }
}