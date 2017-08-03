using Don.Sportsstore.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Don.Sportsstore.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SportsstoreDbContext _context;

        public InitialHostDbBuilder(SportsstoreDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultProductCreator(_context).Create(); 
        }
    }
}
