using System.Collections.Generic;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Web.Models.Product
{
    public class ProductListViewModel
    {
        public IReadOnlyList<ProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }

        public ProductListViewModel(IReadOnlyList<ProductDto> products, PagingInfo pagingInfo, string currentCategory)
        {
            Products = products;
            PagingInfo = pagingInfo;
            CurrentCategory = currentCategory;
        }
    }
}