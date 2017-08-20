using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using Don.Sportsstore.Authorization.Roles;
using Don.Sportsstore.Roles.Dto;

namespace Don.Sportsstore.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : SportsstoreAppServiceBase,IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }



        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions(MultiTenancySides.Tenant)
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task UpdateRolePermissionsTenant(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions(MultiTenancySides.Tenant)
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }


        public async Task UpdateRolePermissionsHost(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions(MultiTenancySides.Host)
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task<ListResultDto<RoleListDto>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var retVal = new ListResultDto<RoleListDto>(roles.MapTo<List<RoleListDto>>());
            return retVal;
        }

        public async Task<ListResultDto<PermissionListDto>> GetPermissionsAsync()
        {
            //todo replace by PermissionFinder
            var permissions2 = PermissionFinder.GetAllPermissions().ToList();
            var permissions = await Task.Run(() => _permissionManager.GetAllPermissions(false).ToList()); //false - disable tenancyfilter
            var retVal = new ListResultDto<PermissionListDto>(permissions.MapTo<List<PermissionListDto>>());
            return retVal;
        }


    }
}