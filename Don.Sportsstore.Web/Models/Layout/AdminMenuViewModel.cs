using Abp.Application.Navigation;

namespace Don.Sportsstore.Web.Models.Layout
{
    public class AdminMenuViewModel
    {
        public UserMenu AdminMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}