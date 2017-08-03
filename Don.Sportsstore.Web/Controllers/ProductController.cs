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

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(GetAllProductsInput input)
        {
            return View();
        }

        public ActionResult List(GetAllProductsInput input, int page)
        {
            input.SkipCount = page;
            var output = _productService.GetAllSync(input);
            var pagingInfo = new PagingInfo(input.SkipCount, input.MaxResultCount, output.TotalCount);
            var model = new ProductListViewModel(output.Items, pagingInfo);
            return View(model);
        }
    }
}