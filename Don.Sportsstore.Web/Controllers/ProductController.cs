using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.Controllers
{
    public class ProductController : SportsstoreControllerBase
    {
        private readonly IProductService _productService;
        

        public ProductController( IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index(GetAllProductsInput input)
        {

            var output = await _productService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                Category = input.Category
            };

            return View(model);
        }

    }
}