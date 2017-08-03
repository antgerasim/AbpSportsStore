using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Don.Sportsstore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ASP.NET Web API Route Config
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" }
            );

/*            routes.MapRoute(
                name: null,
                url: "Product/List/SkipCount{page}",
                defaults: new {Controller = "Product", action = "List" }
            );*/

            /*          routes.MapRoute(
                          name: null,
                          url: "SkipCount{page}",
                          defaults: new {Controller = "Product", action = "List"}
                      );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}