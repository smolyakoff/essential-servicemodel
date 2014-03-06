using System;
using System.Web.Mvc;

namespace Essential.ServiceModel.Web.Mvc
{
    public static class ServiceModelControllerExtensions
    {
        public static MvcResponseHandler Handle(this Controller controller, Response response)
        {
            return new MvcResponseHandler(response, controller, MvcServiceModel.Configuration);
        }
    }
}
