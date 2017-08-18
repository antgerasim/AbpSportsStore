using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Don.Sportsstore.Authorization.Roles;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Roles.Dto
{

    public class UpdateRolePermissionsInput
    {
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}