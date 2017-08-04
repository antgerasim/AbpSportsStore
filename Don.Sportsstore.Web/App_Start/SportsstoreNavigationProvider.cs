using Abp.Application.Navigation;
using Abp.Domain.Repositories;
using Abp.Localization;
using Don.Sportsstore.Authorization;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class SportsstoreNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {

            var sideMenu = new MenuDefinition("SideMenu",
                new LocalizableString("SideMenu", SportsstoreConsts.LocalizationSourceName));

            sideMenu
                .AddItem(new MenuItemDefinition(
                    "All Products",
                    L("All Products"),
                    url: "/Products",
                    icon: "fa fa-product-hunt"
                ))
                .AddItem(new MenuItemDefinition(
                    "Watersports",
                    L("Watersports"),
                    url: "/Watersports",
                    icon: "fa fa-life-ring"
                ))
                .AddItem(new MenuItemDefinition(
                    "Soccer",
                    L("Soccer"),
                    url: "/Soccer",
                    icon: "fa fa-futbol-o"
                ))
                .AddItem(new MenuItemDefinition(
                    "Chess",
                    L("Chess"),
                    url: "/Chess",
                    icon: "fa fa-beer"
                ));

            context.Manager.Menus.Add("SideMenu", sideMenu);

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
                        "Tenants",
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "Users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "About",
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