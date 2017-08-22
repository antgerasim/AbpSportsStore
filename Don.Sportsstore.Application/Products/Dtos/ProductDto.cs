using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Don.Sportsstore.Products.Dtos
{
    [AutoMap(typeof(Product))] //Maps incoming product from tenantrepository to ProductListDto and other way around. AutoMap attribute maps two classes in both direction
    public class ProductDto : EntityDto
    {
        
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}