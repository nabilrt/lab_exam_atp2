using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LabExamAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          //  AutoMapperConfig.Configure();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
