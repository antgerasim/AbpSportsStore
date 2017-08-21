using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.Sportsstore.Roles.Dto;

namespace Don.Sportsstore.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
        Task<ListResultDto<RoleListDto>> GetRolesAsync();
        Task<ListResultDto<PermissionListDto>> GetPermissionsAsync();
    }
}
