using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Portafo1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Application["gestion"] = new 
            Application["idtareaglobal"] = 0;
            Application["idejecucionglobal"] = 0;
            Application["idejecucionglobal2"] = 0;
            Application["idejecucionglobal3"] = 0;
            Application["rut"] = "3";

            Application["ReRutAcep"] = "3";
            Application["ano"] = 0;
            Application["mes"] = 0;

            Application["ati"] = 0;
            Application["atra"] = 0;

            Application["rutrepo"] = "s";
            Application["nombrepo"] = "Pedro bautista";
            Application["anorepo"] = 0;
            Application["mesrepo"] = 0;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}