using System.Web.Mvc;
using Essential.ServiceModel.Infrastructure;

namespace Essential.ServiceModel.Web.Mvc
{
    public class MvcResponseHandler : ResponseHandler<ActionResult>
    {
        public MvcResponseHandler(IResponse response, Controller controller) : base(response)
        {
        }
    }
}
