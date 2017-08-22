using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using Abp.Authorization;
using Abp.Web.Mvc.Authorization;
using Don.Sportsstore.Roles;
using Don.Sportsstore.Roles.Dto;

namespace Don.Sportsstore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SportsstoreControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionManager _permissionManager;

        public HomeController(IRoleAppService roleAppService, IPermissionManager permissionManager)
        {
            _roleAppService = roleAppService;
            _permissionManager = permissionManager;
        }

        public ActionResult Index()
        {
            var systemAdmin = 1;
            // var tenantAdmin = 2;
            var tenantAdmin = 5;


            GrantAllPermissionsTo(systemAdmin);
            //GrantAllPermissionsTo(tenantAdmin);

            return View();
        }

        private void GrantAllPermissionsTo(int adminRoleId)
        {
            //var allPermissions = adminRoleId==1?_permissionManager.GetAllPermissions(false) : _permissionManager.GetAllPermissions();
            var allPermissions = _permissionManager.GetAllPermissions(false);

            var allPermissionsForTenancy = _permissionManager.GetAllPermissions();

            var permStrins = new List<string>();

            foreach (var permission in allPermissions)
            {
                var test = permission;
                //Debug.WriteLine(permission.Name);
                //Debug.WriteLine(permission.DisplayName.ToString());
                //Debug.WriteLine(permission.Description.ToString());
                //Debug.WriteLine(permission.MultiTenancySides.ToString());
                permStrins.Add(permission.Name);
            }

            _roleAppService.UpdateRolePermissions(new UpdateRolePermissionsInput()
            {
                RoleId = adminRoleId,
                GrantedPermissionNames = permStrins
            });
        }
    }
}