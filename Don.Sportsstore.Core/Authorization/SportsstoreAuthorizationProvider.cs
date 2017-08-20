using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Don.Sportsstore.Authorization
{
    public class SportsstoreAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            CreatePagePermission(context);
            CreateTenantAdminPermissions(context);
            CreateHostAdminPermissions(context);
        }

        private void CreateTenantAdminPermissions(IPermissionDefinitionContext context)
        {
            var administration = context.GetPermissionOrNull(PermissionNames.Tenant.Administration);
            if (administration == null)
            {
                administration = context.CreatePermission(PermissionNames.Tenant.Administration, L("Tenant.Administration")
                   ); //leave out MultiTenancySides.Tenant to create permission that is equally valid as for tenant as for host
            }
            //var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            var contentManagement = administration.CreateChildPermission(
                PermissionNames.Tenant.Administration_ContentManagement,
                L("Tenant.ContentManagement"));

            contentManagement.CreateChildPermission(
                PermissionNames.Tenant.Administration_ContentManagement_ListProducts,
                L("Tenant.ListProducts"));

            //var roleManagement = administration.Cre
            var roleManagement =
                administration.CreateChildPermission(PermissionNames.Tenant.Administration_RoleManagement,
                    L("Tenant.RoleManagement"));

            var users = administration.CreateChildPermission(PermissionNames.Tenant.Administration_UserManagement,
                L("Tenant.UserManagement"));
        }

        private void CreateHostAdminPermissions(IPermissionDefinitionContext context)
        {
            var administration = context.GetPermissionOrNull(PermissionNames.Host.Administration);
            if (administration == null)
            {
                administration = context.CreatePermission(PermissionNames.Host.Administration, L("Host.Administration"),
                    multiTenancySides: MultiTenancySides.Host);
            }
            //Host permissions
            var tenants = administration.CreateChildPermission(PermissionNames.Host.Administration_TenantManagement,
                L("Host.TenantManagement"),
                multiTenancySides: MultiTenancySides.Host);
        }

        private static void CreatePagePermission(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"),
                multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SportsstoreConsts.LocalizationSourceName);
        }
    }
}

//IMPORTANT permissions are cached!!! Clear browser cache everytime you make changes here!! Update: Permissiondatabase updates perfectly after fixing DB NAme in Web.config!!
//After adding new permissions, run  _roleAppService.UpdateRolePermissions (e.g in Homecontroller) to update stuff

//https://forum.aspnetboilerplate.com/viewtopic.php?p=10238
//https://forum.aspnetboilerplate.com/viewtopic.php?p=10238
//clear cache 
//https://forum.aspnetboilerplate.com/viewtopic.php?p=10681
