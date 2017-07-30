using Abp.Authorization;
using Don.Sportsstore.Authorization.Roles;
using Don.Sportsstore.MultiTenancy;
using Don.Sportsstore.Users;

namespace Don.Sportsstore.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
