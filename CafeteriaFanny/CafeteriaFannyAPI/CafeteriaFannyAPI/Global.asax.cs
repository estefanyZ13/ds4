using System;
using System.Web;
using System.Web.Http;
using static System.Net.Mime.MediaTypeNames;

namespace CafeteriaFannyAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}