using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.AutoMapper;
using Abp.Threading;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        
        public  ActionResult Index()
        {

            //var output =  _productService.GetAll().MapTo<IList<ProductDto>>();
            var modeList = AsyncHelper.RunSync(()=> _productService.GetAll()) ;
            return View(modeList);

            return View();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}