using System.ComponentModel.DataAnnotations;

namespace Essential.ServiceModel.Examples.Mvc.Domain.Sales
{
    public class CreateProductCommand
    {
        [Required]
        public string Title { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}