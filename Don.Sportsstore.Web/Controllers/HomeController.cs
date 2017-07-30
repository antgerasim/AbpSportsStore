using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Don.Sportsstore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SportsstoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}