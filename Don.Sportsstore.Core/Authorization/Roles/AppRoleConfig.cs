using Abp.MultiTenancy;
using Abp.Zero.Configuration;

namespace Don.Sportsstore.Authorization.Roles
{
    public static class AppRoleConfig
    {
        //Adding Roles
        public static void Configure(IRoleManagementConfig roleManagementConfig)
        {
            //Static host roles
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Host.Admin,
                    MultiTenancySides.Host)
            );

            //Static tenant roles
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(
                    StaticRoleNames.Tenants.Admin,
                    MultiTenancySides.Tenant)
            );

            //Static user roles = ContentManagement
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(StaticRoleNames.Tenants.ContentManager, MultiTenancySides.Tenant));

            //Static user roles = UserManagement
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(StaticRoleNames.Tenants.UserManager, MultiTenancySides.Tenant));

            //Static user roles = PermissionManagement
            roleManagementConfig.StaticRoles.Add(
                new StaticRoleDefinition(StaticRoleNames.Tenants.PermissionManager, MultiTenancySides.Tenant));
        }
    }
}