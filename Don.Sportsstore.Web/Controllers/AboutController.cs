using System.Web.Mvc;

namespace Don.Sportsstore.Web.Controllers
{
    public class AboutController : SportsstoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}