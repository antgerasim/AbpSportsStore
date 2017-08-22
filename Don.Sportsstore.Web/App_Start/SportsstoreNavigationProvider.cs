using Abp.Application.Navigation;
using Abp.Localization;
using Don.Sportsstore.Authorization;

namespace Don.Sportsstore.Web
{
    /// <summary>
    ///     This class defines menus for the application.
    ///     It uses ABP's menu system.
    ///     When you add menu items here, they are automatically appear in angular application.
    ///     See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class SportsstoreNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            //ADMINMENU
            InitAdminMenu(context);
            //SIDEMENU
            InitSideMenu(context);
            //MAINMENU
            InitMainMenu(context);
        }

        private void InitAdminMenu(INavigationProviderContext context)
        {
            var adminMenu = new MenuDefinition("AdminMenu", L("AdminMenu"));

            adminMenu.AddItem(
                new MenuItemDefinition(
                    "Tenants",
                    L("Tenants"),
                    url: "Admin/Tenants",
                    icon: "fa fa-globe",
                    requiredPermissionName: PermissionNames.Pages_Tenants
                    //requiredPermissionName: PermissionNames.Host.Administration
                )
            ).AddItem(
                new MenuItemDefinition(
                    "Content",
                    L("Content"),
                    url: "Admin/Content",
                    icon: "fa fa - info"
                    //requiredPermissionName: PermissionNames.Administration
                )
            ).AddItem(
                new MenuItemDefinition(
                    "Users",
                    L("Users"),
                    url: "Admin/Users",
                    icon: "fa fa-users",
                    //requiredPermissionName: PermissionNames.Pages_Users
                    requiredPermissionName: PermissionNames.Tenant.Administration
                )
            ).AddItem(
                new MenuItemDefinition(
                    "Roles",
                    L("Roles"),
                    url: "Admin/Roles",
                    icon: "fa fa-users",
                    //requiredPermissionName: PermissionNames.Pages_Users
                    requiredPermissionName: PermissionNames.Tenant.Administration
                )
            ).AddItem(
                new MenuItemDefinition(
                    "Permissions",
                    L("Permissions"),
                    url: "Admin/Permissions",
                    icon: "fa fa-users",
                    //requiredPermissionName: PermissionNames.Pages_Users
                    requiredPermissionName: PermissionNames.Tenant.Administration
                )
            );

            context.Manager.Menus.Add("AdminMenu", adminMenu);
        }

        private static void InitSideMenu(INavigationProviderContext context)
        {
            var sideMenu = new MenuDefinition("SideMenu", L("SideMenu"));

            sideMenu
                .AddItem(new MenuItemDefinition(
                    "All Products",
                    L("All Products"),
                    url: "/Products",
                    icon: "fa fa-product-hunt",
                    requiresAuthentication: true
                ))
                .AddItem(new MenuItemDefinition(
                    "Watersports",
                    L("Watersports"),
                    url: "/Watersports",
                    icon: "fa fa-life-ring",
                    requiresAuthentication: true
                ))
                .AddItem(new MenuItemDefinition(
                    "Soccer",
                    L("Soccer"),
                    url: "/Soccer",
                    icon: "fa fa-futbol-o",
                    requiresAuthentication: true
                ))
                .AddItem(new MenuItemDefinition(
                    "Chess",
                    L("Chess"),
                    url: "/Chess",
                    icon: "fa fa-beer",
                    requiresAuthentication: true
                ));

            context.Manager.Menus.Add("SideMenu", sideMenu);
        }

        private static void InitMainMenu(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Admin",
                        L("Admin"),
                        url: "Admin/Index", //todo fix after adding default value for {action} in routeconfig
                        icon: "fa fa - info",
                        //requiredPermissionName: PermissionNames.Pages_Users
                        requiredPermissionName: PermissionNames.Tenant.Administration
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "About/Index", //todo fix after adding default value for {action} in routeconfig
                        icon: "fa fa-info"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SportsstoreConsts.LocalizationSourceName);
        }
    }
}