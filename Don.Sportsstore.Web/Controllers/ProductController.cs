using System.Threading.Tasks;
using System.Web.Mvc;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.Controllers
{
    public class ProductController : SportsstoreControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(GetAllProductsInput input)//can be removed? todo change routing and make redirect to action List 
        {
            return View();
        }

/*
        public ActionResult List(GetAllProductsInput input, int page)
        {
            input.SkipCount = page;
            var output = _productService.GetAllSync(input);
            var pagingInfo = new PagingInfo(input.SkipCount, input.MaxResultCount, output.TotalCount);
            var category = input.Category == null ? "Products" : input.Category;
            var model = new ProductListViewModel(output.Items, pagingInfo, category);
            return View(model);
        }
*/

        public async Task<ActionResult> List(GetAllProductsInput input, int page)
        {
            input.SkipCount = page;
            var output = await _productService.GetAll(input);
            var pagingInfo = new PagingInfo(input.SkipCount, input.MaxResultCount, output.TotalCount);
            var category = input.Category == null ? "Products" : input.Category;
            var model = new ProductListViewModel(output.Items, pagingInfo, category);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductListViewModel.ProductInfo viewModel)
        {
            var input = ObjectMapper.Map<CreateUpdateProductInput>(viewModel);
            await _productService.UpdateProduct(input);

            TempData["message"] = $"{viewModel.Name} has been saved";

            return RedirectToAction("Index");


        }
    }
}