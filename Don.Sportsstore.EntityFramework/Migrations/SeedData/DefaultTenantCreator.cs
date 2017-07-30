using System.Linq;
using Don.Sportsstore.EntityFramework;
using Don.Sportsstore.MultiTenancy;

namespace Don.Sportsstore.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly SportsstoreDbContext _context;

        public DefaultTenantCreator(SportsstoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
