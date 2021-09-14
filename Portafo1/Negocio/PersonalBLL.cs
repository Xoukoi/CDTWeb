using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class PersonalBLL : WebPageTraceListener
    {
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string APEPATE { get; set; }
        public int TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string CONTRASENIA { get; set; }
        public string ESTADO { get; set; }
        public string CARGO { get; set; }
        public string uniNom { get; set; }




        public List<PersonalBLL> listarPersonalAso(string rut)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            List<PersonalBLL> lista = new List<PersonalBLL>();

            foreach (var item in wcf.ListarPersonalAsociadoAUnJefe(rut))
            {

                PersonalBLL otro = new PersonalBLL();
                otro.RUT = item.Rut;
                otro.NOMBRE = item.Nombre;
                otro.APEPATE = item.APaterno;
                otro.TELEFONO = item.Telefono;
                otro.CORREO = item.Correo;
                otro.CARGO = item.Cargo;
                otro.uniNom = item.Unidad_nombre;
                lista.Add(otro);

            }
            return lista;

        }

    }
}