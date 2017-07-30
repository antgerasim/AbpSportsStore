using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Don.Sportsstore.EntityFramework;

namespace Don.Sportsstore
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SportsstoreCoreModule))]
    public class SportsstoreDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SportsstoreDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
