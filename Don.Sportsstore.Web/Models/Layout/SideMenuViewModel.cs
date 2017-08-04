using Abp.Application.Navigation;

namespace Don.Sportsstore.Web.Models.Layout
{
    public class SideMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}