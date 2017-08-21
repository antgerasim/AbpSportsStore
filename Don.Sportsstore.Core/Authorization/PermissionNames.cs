namespace Don.Sportsstore.Authorization
{
    public static class PermissionNames
    {
        public const string Pages = "Pages";

        public const string Pages_Tenants = "Pages.Tenants";

        public const string Pages_Users = "Pages.Users";

        public class Tenant
        {
            //Administration
            public const string Administration = "Tenant_Administration";

            //Administration.ContentManagement;
            public const string Administration_ContentManagement = "Tenant_Administration.ContentManagement";

            public const string Administration_ContentManagement_ListProducts =
                "Tenant_Administration.ContentManagement.ListProducts";


            public const string Administration_RoleManagement = "Tenant_Administration.RoleManagement";

            public const string Administration_UserManagement = "Tenant_Administration.UserManagement";


            //public const string Administration_TenantManagement = "Tenant_Administration.TenantManagement";
        }

        public class Host
        {
            public const string Administration = "Host_Administration";
            public const string Administration_TenantManagement = "Host_Administration.TenantManagement";
        }
    }
}