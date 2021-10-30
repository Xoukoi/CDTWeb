using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class IdTareasBLL
    {

        public int idTarea { get; set; }

        public IdTareasBLL()
        {
        }

        public List<IdTareasBLL> listarIdTareas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            foreach (var item in wcf.BuscarIdTareas(rut))
            {

                IdTareasBLL otro = new IdTareasBLL();
                otro.idTarea = item.idtarea;
                lista.Add(otro);

            }
            return lista;

        }

        public int buscarIdProce(string nomProc)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.BuscarIdProce(nomProc))
            {                            

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }
        public int contarTareas()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarTareas())
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarTareasAceptadas(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarTareasAceptadas(rut,ano,mes))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarTareasRechazadas(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarTareasRechazadas(rut, ano, mes))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarTareasAtiempo(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarTareasAtiempo(rut))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarTareasAtrasadas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarTareasAtrasadas(rut))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarProcesos()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarProcesos())
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }
        public int contarEjecucioness()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarEJecuciones())
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }
        public int contarEstadosTar()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarEstadosTar())
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }

        public int contarCargadeTrabajo(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.ContarejecucionesAceptadas(rut))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }
        public int contarCargadeTrabajoasignadas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<IdTareasBLL> lista = new List<IdTareasBLL>();

            int or = 0;
            foreach (var item in wcf.Contarejecucionesporconfirmar(rut))
            {

                IdTareasBLL otro = new IdTareasBLL();
                or = item.idtarea;
                lista.Add(otro);

            }
            return or;

        }
    }
}
