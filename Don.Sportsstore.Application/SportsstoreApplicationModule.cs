using System.Configuration;
using System.Reflection;
using System.Web;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Don.Sportsstore.Orders;

namespace Don.Sportsstore
{
    [DependsOn(typeof(SportsstoreCoreModule), typeof(AbpAutoMapperModule))]
    public class SportsstoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //IocManager.IocContainer.Register(Classes.FromThisAssembly().BasedOn<IMySpecialInterface>().LifestylePerThread().WithServiceSelf());
            //IocManager.Register<IOrderProcessor, EmailOrderProcessor>(DependencyLifeStyle.Transient);
            //https://stackoverflow.com/questions/8295167/castle-windsor-3-with-constructor-argument-as-string
            var writeAsFile = ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false";
            /*       IocManager.IocContainer.Register(Component.For<IOrderProcessor>().ImplementedBy<EmailOrderProcessor>()
                       .DependsOn(new EmailSettings
                           {
                               WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
                           }
                       )
                   );*/
/*
            IocManager.IocContainer.Register(Component.For<Carts.Cart>()
                .UsingFactoryMethod(() => HttpContext.Current.Session["Cart"] as Carts.Cart).LifeStyle.PerWebRequest);*/

     /*       IocManager.IocContainer.Register(Component.For<HttpSessionStateBase>()
                .UsingFactoryMethod(() => new HttpSessionStateWrapper(HttpContext.Current.Session))
                .LifeStyle
                .PerWebRequest);*/
        }
    }
}