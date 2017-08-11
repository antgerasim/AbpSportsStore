using System.Configuration;
using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Don.Sportsstore.Authorization;
using Don.Sportsstore.Authorization.Roles;
using Don.Sportsstore.MultiTenancy;
using Don.Sportsstore.Orders;
using Don.Sportsstore.Users;

namespace Don.Sportsstore
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class SportsstoreCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = SportsstoreConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SportsstoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Don.Sportsstore.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<SportsstoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // var writeAsFile = ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false";
            var writeAsFile = "true";

/*            IocManager.IocContainer.Register(Component.For<IOrderManager>().ImplementedBy<OrderManager>()
                .DependsOn(new EmailSettings
                    {
                        WriteAsFile = bool.Parse(writeAsFile)
                    }
                )
            );*/
        }
    }
}
