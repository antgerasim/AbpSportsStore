using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.AutoMapper;
using Abp.Threading;
using Abp.Web.Mvc.Authorization;
using Don.Sportsstore.Authorization;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Roles;
using Don.Sportsstore.Users;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserAppService _userAppService;
        private readonly IRoleAppService _roleAppService;

        public AdminController(IProductService productService, IUserAppService userAppService, IRoleAppService roleAppService)
        {
            _productService = productService;
            _userAppService = userAppService;
            _roleAppService = roleAppService;
        }
        
        public  ActionResult Index()
        {
     
            return View();
        }

        public async Task<ActionResult> Content()
        {
            var modeList = await _productService.GetAll();
            return View(modeList);
        }

        public async Task<ActionResult> Users()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }

        //create read update delete Roles
        public ActionResult Roles()
        {
           // var output = await _roleAppService.
            return View();
        }

        public ActionResult Permissions()
        {
            return View();
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}