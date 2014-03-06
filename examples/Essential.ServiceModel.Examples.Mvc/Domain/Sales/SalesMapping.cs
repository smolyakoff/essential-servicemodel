using AutoMapper;

namespace Essential.ServiceModel.Examples.Mvc.Domain.Sales
{
    public class SalesMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}