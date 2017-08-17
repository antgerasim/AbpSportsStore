namespace Don.Sportsstore.Authorization.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            public const string Admin = "Admin";
        }

        public static class Tenants
        {
            public const string Admin = "Admin";
            public const string ContentManager = "ContentManager";
            public const string PermissionManager = "PermissionManager";
            public const string UserManager = "UserManager";
        }
    }
}