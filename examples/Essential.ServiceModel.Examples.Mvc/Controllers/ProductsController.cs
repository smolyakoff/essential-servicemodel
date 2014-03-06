using System.Web.Mvc;
using Essential.ServiceModel.Examples.Mvc.Domain.Sales;
using Essential.ServiceModel.Web.Mvc;

namespace Essential.ServiceModel.Examples.Mvc.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private readonly SalesService _salesService = new SalesService();

        [HttpGet]
        [Route("", Name = "GetAllProducts")]
        public ActionResult Index()
        {
            var response = _salesService.GetAllProducts();
            return this.Handle(response).Execute();
        }

        [HttpGet]
        [Route("create", Name = "CreateProductView")]
        public ActionResult CreateView()
        {
            var model = TempData["Model"];
            var modelState = TempData["ModelState"] as ModelStateDictionary;
            if (modelState != null)
            {
                ModelState.Merge(modelState);
            }
            return View("Create", model);
        }

        [HttpPost]
        [Route("", Name = "CreateProductCommand")]
        public ActionResult Create(CreateProductCommand command)
        {
            var response = _salesService.CreateProduct(command);
            return this.Handle(response)
                .On<Invalid>().React(i =>
                {
                    TempData["Model"] = command;
                    TempData["ModelState"] = ModelState;
                    return RedirectToAction("CreateView");
                })
                .On<Success>().React(s => RedirectToAction("Index"))
                .Execute();
        }

    }
}