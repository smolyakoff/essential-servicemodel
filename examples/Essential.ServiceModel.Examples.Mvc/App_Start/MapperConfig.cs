using AutoMapper;
using Essential.ServiceModel.Examples.Mvc.Domain.Sales;

namespace Essential.ServiceModel.Examples.Mvc
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.AddProfile<SalesMapping>();
        }
    }
}