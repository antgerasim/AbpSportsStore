using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.Sportsstore.Authorization.Roles;

namespace Don.Sportsstore.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleListDto : EntityDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int TenantId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}