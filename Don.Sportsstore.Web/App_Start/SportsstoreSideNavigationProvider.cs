using Abp.Application.Navigation;
using Abp.Localization;
using Don.Sportsstore.Authorization;

namespace Don.Sportsstore.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class SportsstoreSideNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
//todo inject product repository and get categories over linq

            var sideMenu = new MenuDefinition("SideBarMenu",
                new LocalizableString("SideBarMenu", SportsstoreConsts.LocalizationSourceName));

            sideMenu
                .AddItem(new MenuItemDefinition(
                    "Watersports",
                    L("Watersports"),
                    url: "/Watersports",
                    icon: "fa fa-info"
                ))
                .AddItem(new MenuItemDefinition(
                    "Soccer",
                    L("Soccer"),
                    url: "/Soccer",
                    icon: "fa fa-info"
                ))
                .AddItem(new MenuItemDefinition(
                    "Chess",
                    L("Chess"),
                    url: "/Chess",
                    icon: "fa fa-info"
                ));

            context.Manager.Menus.Add("SideMenu", sideMenu);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SportsstoreConsts.LocalizationSourceName);
        }
    }
}