using System.Collections.Generic;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Web.Models.Product
{
    public class ProductViewModel
    {
        public IReadOnlyList<ProductListDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string Category { get; set; }

        public ProductViewModel(IReadOnlyList<ProductListDto> products, PagingInfo pagingInfo)
        {
            Products = products;
            PagingInfo = pagingInfo;
        }
    }
}