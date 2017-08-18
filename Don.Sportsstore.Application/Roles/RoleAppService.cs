using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
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
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task<ListResultDto<RoleListDto>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var retVal = new ListResultDto<RoleListDto>(roles.MapTo<List<RoleListDto>>());
            return retVal;
        }
    }
}