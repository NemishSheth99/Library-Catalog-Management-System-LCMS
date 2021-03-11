using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace LCMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ILog log = log4net.LogManager.GetLogger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ServiceProxy.ServiceProxySettings.SetSettings(ConfigurationManager.AppSettings["ServiceBaseAddress"], Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"]));
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            log.Error(exception);
            Server.ClearError();
            Response.Redirect("/ApplicationUser/InternalServerError");
        }
    }
}
