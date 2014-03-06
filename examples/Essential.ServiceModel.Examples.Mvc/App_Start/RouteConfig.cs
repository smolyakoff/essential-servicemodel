using System.Web.Mvc;
using System.Web.Routing;

namespace Essential.ServiceModel.Examples.Mvc
{
    public static class RouteConfig
    {
        public static void RegisterRoutes()
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
        }
    }
}