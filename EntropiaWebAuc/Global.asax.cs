using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EntropiaWebAuc.Infrastructure;
using EntropiaWebAuc.Areas.Admin;
using EntropiaWebAuc.Areas.Default;



namespace EntropiaWebAuc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var adminArea = new AdminAreaRegistration();
            var adminAreaContext = new AreaRegistrationContext(adminArea.AreaName,
        RouteTable.Routes);
            adminArea.RegisterArea(adminAreaContext);

            var defaultArea = new DefaultAreaRegistration();
            var defaultAreaContext = new AreaRegistrationContext(defaultArea.AreaName,
RouteTable.Routes);
            defaultArea.RegisterArea(defaultAreaContext); 


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
