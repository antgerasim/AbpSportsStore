using System;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;

namespace Don.Sportsstore.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionListDto : EntityDto
    {
        public int TenantId { get; set; }

        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public DateTime CreationTime { get; set; }
        public int RoleId { get; set; }
    }
}