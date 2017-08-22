using System.Collections.Generic;
using Abp.AutoMapper;
using Don.Sportsstore.MultiTenancy;

namespace Don.Sportsstore.Web.Models.Account
{
    public class TenantSelectionViewModel
    {
        public string Action { get; set; }

        public List<TenantInfo> Tenants { get; set; }

        [AutoMapFrom(typeof(Tenant))]
        public class TenantInfo
        {
            public int Id { get; set; }

            public string TenancyName { get; set; }

            public string Name { get; set; }
        }
    }
}

//automapper comments https://github.com/aspnetboilerplate/aspnetboilerplate/issues/175