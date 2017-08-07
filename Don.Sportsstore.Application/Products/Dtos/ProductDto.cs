using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Don.Sportsstore.Products.Dtos
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}