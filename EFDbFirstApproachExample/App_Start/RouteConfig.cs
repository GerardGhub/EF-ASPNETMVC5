using System.Web.Mvc;
using System.Web.Routing;

namespace EFDbFirstApproachExample
{
    // This class is responsible for configuring route mappings for the ASP.NET MVC application
    public class RouteConfig
    {
        // This method is used to register routes for the application
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignores requests for specific files like WebResource.axd or ScriptResource.axd
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Defines the default route pattern for the applicatiob
            routes.MapRoute(
                name: "Default", // Name of the route
                url: "{controller}/{action}/{id}", // URL pattern
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },  // Default values for the route parameters
                namespaces: new[] { "EFDbFirstApproachExample.Controllers" } // Namespace for the controllers
            );
        }
    }
}
