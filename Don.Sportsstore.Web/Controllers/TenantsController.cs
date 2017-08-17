using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Don.Sportsstore.Authorization;
using Don.Sportsstore.MultiTenancy;

namespace Don.Sportsstore.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : SportsstoreControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}