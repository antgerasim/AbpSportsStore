using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Web.Models.Product;
using WebGrease.Css.Extensions;

namespace Don.Sportsstore.Web.Controllers
{
    public class ProductController : SportsstoreControllerBase
    {
        private readonly IProductService _productService;
        //public int PageSize = 4;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index(GetAllProductsInput input)
        {
            var currentPage = input.SkipCount == 0 ? 1 : input.SkipCount;
            input.SkipCount = currentPage;

            var output = await _productService.GetAll(input);

            var pagingInfo = new PagingInfo(currentPage, input.MaxResultCount, output.TotalCount);
            var model = new ProductViewModel(output.Items, pagingInfo);

            return View(model);
        }
    }
}