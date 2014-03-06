using System.Collections.Generic;
using AutoMapper;
using Essential.ServiceModel.Validation;
using Essential.ServiceModel.Validation.Conditions;

namespace Essential.ServiceModel.Examples.Mvc.Domain.Sales
{
    public class SalesService
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product {Title = "Bag", Price = 10},
            new Product {Title = "Jeans", Price = 15},
            new Product {Title = "Jacket", Price = 20}
        }; 

        public Response GetAllProducts()
        {
            var productModels = Mapper.Map<List<ProductModel>>(Products);
            return new Data<List<ProductModel>>(productModels);
        }

        public Response CreateProduct(CreateProductCommand command)
        {
            var invalid = ValidationFault.For("Name").Required(command.Title.Condition().Empty(), "The product should have a name.")
                .For("Price").OutOfRange(() => command.Price <= 0, "The price should be greater than zero.")
                .InvalidOrNull("Invalid command parameters");
            if (invalid != null)
            {
                return invalid;
            }
            var product = Mapper.Map<CreateProductCommand, Product>(command);
            Products.Add(product);
            return new Success();
        }
    }
}