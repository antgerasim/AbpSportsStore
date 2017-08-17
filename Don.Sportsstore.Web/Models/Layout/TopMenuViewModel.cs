using Abp.Application.Navigation;

namespace Don.Sportsstore.Web.Models.Layout
{
    public class TopMenuViewModel
    {
        public UserMenu TopMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}