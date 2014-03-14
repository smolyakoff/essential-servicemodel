using System;
using Essential.ServiceModel.Examples.Mvc.App_Start;

namespace Essential.ServiceModel.Examples.Mvc
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles();
            RouteConfig.RegisterRoutes();

            MapperConfig.Configure();
            
        }
    }
}