using System;
using System.Web.Mvc;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Don.Sportsstore.Carts;
using Don.Sportsstore.Web.Binders;

namespace Don.Sportsstore.Web
{
    public class MvcApplication : AbpWebApplication<SportsstoreWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            base.Application_Start(sender, e);
        }
    }
}