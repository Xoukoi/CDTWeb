using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portafo1.Negocio
{
    public class EstadoTarBLL
    {
        public void AgregarTarea(ServiceReference1.EstadoTarN item)
        {
            ServiceReference1.WebService1SoapClient wcf = new ServiceReference1.WebService1SoapClient();
            ServiceReference1.EstadoTarN estaTarea = new ServiceReference1.EstadoTarN();
            wcf.AgregarEstadoTar(item);
        }
    }
}