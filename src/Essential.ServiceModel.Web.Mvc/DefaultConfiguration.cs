using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essential.ServiceModel.Validation.Faults;

namespace Essential.ServiceModel.Web.Mvc
{
    internal class DefaultConfiguration
    {
        private readonly Controller _controller;

        public static void Apply(MvcResponseHandler handler, Controller controller)
        {
            var config = new DefaultConfiguration(controller);
            handler.On<Success>().React(config.ReactOnSuccess)
                   .On<Data>().React(config.ReactOnData)
                   .On<Failure>().React(config.ReactOnFailure)
                   .On<Error>().Do(config.OnError).React(config.ReactOnError)
                   .On<Invalid>().Do(config.OnInvalid).React(config.ReactOnInvalid);
        }

        private DefaultConfiguration(Controller controller)
        {
            _controller = controller;
        }

        private void OnInvalid(Invalid invalid)
        {
            foreach (var fault in invalid.Faults.OfType<ParameterFault>())
            {
                _controller.ModelState.AddModelError(fault.Name, fault.Message);
            }
        }

        private ActionResult ReactOnInvalid(Invalid invalid)
        {
            throw new HttpException((int) HttpStatusCode.BadRequest, invalid.Message);
        }

        private ActionResult ReactOnFailure(Failure failure)
        {
            throw new HttpException((int) HttpStatusCode.InternalServerError, failure.Message);
        }

        private void OnError(Error error)
        {
            HttpContext.Current.AddError(error.GetException());
        }

        private ActionResult ReactOnError(Error error)
        {
            throw error.GetException();
        }

        private ActionResult ReactOnSuccess(Success success)
        {
            return View();
        }

        private ActionResult ReactOnData(Data data)
        {
            return View(data.GetValue());
        }

        private ViewResult View(object model = null)
        {
            if (model != null)
            {
                _controller.ViewData.Model = model;
            }
            var viewResult = new ViewResult
            {
                ViewData = _controller.ViewData,
                TempData = _controller.TempData,
                ViewEngineCollection = _controller.ViewEngineCollection,
            };
            return viewResult;
        }
    }
}
