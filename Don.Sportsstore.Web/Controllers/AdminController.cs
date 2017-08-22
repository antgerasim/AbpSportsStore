using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Security.AntiForgery;
using Don.Sportsstore.Authorization;
using Don.Sportsstore.Products;
using Don.Sportsstore.Products.Dtos;
using Don.Sportsstore.Roles;
using Don.Sportsstore.Users;
using Don.Sportsstore.Web.Models.Product;

namespace Don.Sportsstore.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Tenant.Administration)]
    public class AdminController : SportsstoreControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRoleAppService _roleAppService;
        private readonly IUserAppService _userAppService;

        public AdminController(IProductService productService, IUserAppService userAppService,
            IRoleAppService roleAppService)
        {
            _productService = productService;
            _userAppService = userAppService;
            _roleAppService = roleAppService;
        }

        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("ProductList");
        }

        public async Task<ActionResult> ProductList()
        {
            var output = await _productService.GetAll();//todo replace by ProductListViewModel -> enable pagination
            return View(output);
        }

        //[AbpMvcAuthorize(PermissionNames.Tenant.Administration_ContentManagement)]
        public async Task<ActionResult> Content()
        {
            var modeList = await _productService.GetAll();
            return View(modeList);
        }

        public async Task<ActionResult> Users()
        {
            //var output = await _userAppService.GetUsers();
            //return View(output);
            return await Task.Run<ActionResult>(() => RedirectToAction("Index", "Users"));
        }

        //create read update delete Roles
        public async Task<ActionResult> Roles()
        {
            //Task run will use a different thread to the code passed.
            return await Task.Run<ActionResult>(() => RedirectToAction("RoleList"));
        }

        public async Task<ActionResult> RoleList()
        {
            var output = await _roleAppService.GetRolesAsync();
            return View(output);
        }

        public async Task<ActionResult> Permissions()
        {
            //Task run will use a different thread to the code passed.
            return await Task.Run<ActionResult>(() => RedirectToAction("PermissionList"));
        }


        public async Task<ActionResult> PermissionList()
        {
            var output = await _roleAppService.GetPermissionsAsync();
            return View(output);
        }

        // [AbpMvcAuthorize(PermissionNames.Host.Administration)]
        //[AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
        public async Task<ActionResult> Tenants()
        {
            return await Task.Run<ActionResult>(() => RedirectToAction("Index", "Tenants"));
        }

        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var input = new EntityDto<int>(id);
            var output = await _productService.Get(input);

            return View(output);
        }

        [HttpPost]
        [DisableAbpAntiForgeryTokenValidation]
        //public async Task<ActionResult> Edit(ProductDto product)
        public async Task<ActionResult> Edit(ProductListViewModel.ProductInfo viewModel)
        {
            var indsfdsf = viewModel.MapTo<CreateUpdateProductInput>();

            //var input = ObjectMapper.Map<UpdateProductInput>(viewModel);
            await _productService.UpdateProduct(indsfdsf);
            TempData["message"] = $"{viewModel.Name} has been saved";
            return RedirectToAction("Index");
        }
    }
}