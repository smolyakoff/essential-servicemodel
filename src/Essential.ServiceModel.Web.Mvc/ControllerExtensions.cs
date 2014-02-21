using System;
using System.Web.Mvc;
using Essential.ServiceModel.Infrastructure;

namespace Essential.ServiceModel.Web.Mvc
{
    public static class ControllerExtensions
    {
        public static ResponseHandler<ActionResult> Handle(this Controller controller, IResponse response)
        {
            var handler = new MvcResponseHandler(response, controller);
            return handler;  
        } 
    }
}
