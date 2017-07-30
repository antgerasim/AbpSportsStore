using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Don.Sportsstore.EntityFramework;

namespace Don.Sportsstore.Migrator
{
    [DependsOn(typeof(SportsstoreDataModule))]
    public class SportsstoreMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SportsstoreDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}