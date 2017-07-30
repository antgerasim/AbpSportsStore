using System.Threading.Tasks;
using Abp.Application.Services;
using Don.Sportsstore.Roles.Dto;

namespace Don.Sportsstore.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
