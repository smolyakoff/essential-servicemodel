using System;

namespace Essential.ServiceModel.Examples.Mvc
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MapperConfig.Configure();
            RouteConfig.RegisterRoutes();
        }
    }
}