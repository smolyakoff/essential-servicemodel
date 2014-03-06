namespace Essential.ServiceModel.Examples.Mvc.Domain.Sales
{
    public class CreateProductCommand
    {
        public string Title { get; set; }

        public decimal Price { get; set; }
    }
}