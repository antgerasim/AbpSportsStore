using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.Mvc.Configuration;
using Abp.Web.SignalR;
using Castle.MicroKernel.Registration;
using Don.Sportsstore.Api;
using Hangfire;


namespace Don.Sportsstore.Web
{
    [DependsOn(
        typeof(SportsstoreDataModule),
        typeof(SportsstoreApplicationModule),
        typeof(SportsstoreWebApiModule),
        typeof(AbpWebSignalRModule),
        //typeof(AbpHangfireModule), - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        typeof(AbpWebMvcModule))]
    public class SportsstoreWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<SportsstoreNavigationProvider>();
            //Disable validation for controllers
            //Configuration.Modules.AbpMvc().IsValidationEnabledForControllers = false;

            /*          Configuration.Navigation.Providers.Add<SportsstoreSideNavigationProvider>();*/

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});
        }

        public override void Initialize()
        {
            var test = HttpContext.Current;
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());




            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
