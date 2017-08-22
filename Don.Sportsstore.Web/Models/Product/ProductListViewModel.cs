using System.Collections.Generic;
using Abp.AutoMapper;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Web.Models.Product
{
    public class ProductListViewModel
    {
        public ProductListViewModel(IReadOnlyList<ProductDto> products, PagingInfo pagingInfo, string currentCategory)
        {
            Products = products;
            PagingInfo = pagingInfo;
            CurrentCategory = currentCategory;
        }

        public IReadOnlyList<ProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        // [AutoMapTo(typeof(ProductDto))]
        [AutoMap(typeof(CreateUpdateProductInput))]
        public class ProductInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
    }
}