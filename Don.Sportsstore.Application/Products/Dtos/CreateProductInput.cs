using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Don.Sportsstore.Products.Dtos
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}