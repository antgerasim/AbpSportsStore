using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Don.Sportsstore.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]//Maps incoming tenant from tenantrepository to TenantListDto. From system to view
    public class TenantListDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}