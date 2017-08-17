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
            CreateAdminPermission(context);
        }

        private void CreateAdminPermission(IPermissionDefinitionContext context)
        {
            var administration = context.GetPermissionOrNull(PermissionNames.Administration);
            if (administration == null)
            {
                administration = context.CreatePermission(PermissionNames.Administration, L("Administration"));
            }
            //var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            var userManagement = administration.CreateChildPermission(PermissionNames.Administration_ContentManagement,
                L("ContentManagement"));
            userManagement.CreateChildPermission(PermissionNames.Administration_ContentManagement_ListProducts,
                L("ListProducts"));

            //var roleManagement = administration.Cre
            var roleManagement =
                administration.CreateChildPermission(PermissionNames.Administration_RoleManagement, L("RoleManagement"));
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