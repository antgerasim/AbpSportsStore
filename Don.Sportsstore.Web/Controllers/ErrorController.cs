using System;
using System.Web.Mvc;
using Abp.Web.Models;
using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.Models;

namespace Don.Sportsstore.Web.Controllers
{
/*    public class ErrorController : AbpController
    {
        private readonly IErrorInfoBuilder _errorInfoBuilder;

        public ErrorController(IErrorInfoBuilder errorInfoBuilder)
        {
            _errorInfoBuilder = errorInfoBuilder;
        }

        public ActionResult Index()
        {
/*            var exHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
           

            var exception = exHandlerFeature != null
                ? exHandlerFeature.Error
                : new Exception("Unhandled exception!");

            return View(
                "Error",
                new ErrorViewModel(
                    _errorInfoBuilder.BuildForException(exception),
                    exception
                )
            );#1#
        }
    }*/
}