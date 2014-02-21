using System;
using System.Web.Mvc;
using Essential.ServiceModel.Infrastructure;

namespace Essential.ServiceModel.Web.Mvc
{
    public static class ResponseExtensions
    {
        public static void Handle(this IResponse response)
        {
            var handler = new ResponseHandler<ViewResult>(response);
            handler.On<Failure>()
                .Do(x => Console.Write(x.Message))
                .React(x => new ViewResult() {});
        }
    }
}
