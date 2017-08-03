using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Don.Sportsstore.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace Don.Sportsstore.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Sportsstore.EntityFramework.SportsstoreDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sportsstore";
        }

        protected override void Seed(Sportsstore.EntityFramework.SportsstoreDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
                new DefaultProductCreator(context).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
                new DefaultProductCreator(context).Create();
            }

            context.SaveChanges();
        }
    }
}
