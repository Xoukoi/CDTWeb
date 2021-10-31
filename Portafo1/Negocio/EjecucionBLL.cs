using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class EjecucionBLL
    {

        public int idEjecu { get; set; }
        public string descripcionEje { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public DateTime FechaEjec { get; set; }
        public string personal_rut { get; set; }
        public string semaforo { get; set; }
        public string notficacion { get; set; }
        public string tipotarea { get; set; }
        public string nombreTarea { get; set; }
        public string descripcionTarea { get; set; }
        public string observacionTarea { get; set; }
        public string adjudicador { get; set; }
        
        public string color { get; set; }

        public void AgregarEjecucion(ServiceReference1.EjecucionN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.EjecucionN  ejecu = new ServiceReference1.EjecucionN();
            wcf.AgregarEjecucion(item);
        }

        public List<EjecucionBLL> listaEjecucionesPorConfirmar(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ListarEjecucionesPorConfirmar(rut))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }

        public List<EjecucionBLL> listaEjecucionesRechazadas()
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ListarEjecucionesRechazadas())
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }

        public List<EjecucionBLL> listaEjecucionesAceptadas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ListarEjecucionesAceptadas(rut))
            {
                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.FechaEjec = item.fechaEjecucion;
                DateTime ini = DateTime.Today;
                DateTime fin = item.fechaTermino;

                TimeSpan difFechas = fin - ini;
                int sed = difFechas.Days;
                if (sed >= 7)
                {
                    otro.color = "green";
                }
                if (sed < 7 && sed > 3)
                {
                    otro.color = "yellow";
                }
                if (sed <= 3)
                {
                    otro.color = "red";
                }
                otro.semaforo = ""+sed;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }

        public string listaEjecucionesAceptadas2(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            StringWriter lista = new StringWriter();

            string tipo = "";

            foreach (var item in wcf.ListarEjecucionesAceptadas(rut))
            {

                EjecucionBLL otro = new EjecucionBLL();

                otro.notficacion = item.notifi;

                lista.Write(otro);

            }
            return lista.ToString();

        }

        public List<EjecucionBLL> ReportelistaEjecucionesAceptadas(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ReporteListarEjecucionesAceptadas(rut, ano, mes))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.FechaEjec = item.fechaEjecucion;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }


        public List<EjecucionBLL> ReportelistaEjecucionesatiempo(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ReporteListarEjecucionesatiempo(rut, ano, mes))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.FechaEjec = item.fechaEjecucion;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }

        public List<EjecucionBLL> ReportelistaEjecucionesatrasadas(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ReporteListarEjecucionesatrasadas(rut, ano, mes))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.FechaEjec = item.fechaEjecucion;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }

        public List<EjecucionBLL> ReportelistaEjecucionesrechazadas(string rut, int ano, int mes)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

            string tipo = "";

            foreach (var item in wcf.ReporteListarEjecucionesRechazadas(rut, ano, mes))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.fechaInicio = item.fechaInicio;
                otro.fechaTermino = item.fechaTermino;
                otro.FechaEjec = item.fechaEjecucion;
                otro.semaforo = item.semaforo;
                otro.notficacion = item.notifi;
                if (item.tipota == 1)
                {
                    tipo = "Normal";
                }
                else
                {
                    tipo = "Tarea de flujo";
                }
                otro.tipotarea = tipo;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.adjudicador = item.rutAdjudicador;
                lista.Add(otro);

            }
            return lista;

        }


        public List<EjecucionBLL> listaEjecucionesTerminadas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();

           

            foreach (var item in wcf.ListarEjecucionesTerminadas(rut))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.FechaEjec = item.fechaEjecucion;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.personal_rut = item.personal_rut;
                lista.Add(otro);

            }
            return lista;

        }
        public List<EjecucionBLL> listaEjecucionesRevisadas(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<EjecucionBLL> lista = new List<EjecucionBLL>();



            foreach (var item in wcf.ListarEjecucionesRevisadas(rut))
            {

                EjecucionBLL otro = new EjecucionBLL();
                otro.idEjecu = item.idEjec;
                otro.descripcionEje = item.descrip;
                otro.FechaEjec = item.fechaEjecucion;
                otro.nombreTarea = item.nombreta;
                otro.descripcionTarea = item.descripcionTar;
                otro.observacionTarea = item.observacionTar;
                otro.personal_rut = item.personal_rut;
                lista.Add(otro);

            }
            return lista;

        }

        public void cambiarEstadoEjecucion(ServiceReference1.EjecucionN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.EjecucionN ejecu = new ServiceReference1.EjecucionN();
            wcf.cambiarEstadoEjecucion(item);
        }

    }
}