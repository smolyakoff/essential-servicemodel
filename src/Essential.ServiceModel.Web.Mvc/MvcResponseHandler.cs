using System;
using System.Web.Mvc;
using Essential.ServiceModel.Infrastructure;

namespace Essential.ServiceModel.Web.Mvc
{
    public class MvcResponseHandler : ResponseHandler<ActionResult>
    {
        internal MvcResponseHandler(Response response, Controller controller,
            Action<MvcResponseHandler, Controller> configuration) : base(response)
        {
            configuration(this, controller);
        }
    }
}
