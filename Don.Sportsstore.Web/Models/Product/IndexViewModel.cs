using System.Collections.Generic;
using Don.Sportsstore.Products.Dtos;

namespace Don.Sportsstore.Web.Models.Product
{
    public class IndexViewModel
    {
        public IReadOnlyList<ProductListDto> Products { get; }
  

        public string Category { get; set; }

        public IndexViewModel( IReadOnlyList<ProductListDto> products)
        {
            Products = products;
            //_products = products;
        }
    }
}