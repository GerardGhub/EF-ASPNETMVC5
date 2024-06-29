using System.Web.Mvc;

namespace EFDbFirstApproachExample
{
    // This class is responsible for registering global filters in the ASP.NET MVC application
    public class FilterConfig
    {
        // This method is used to register global filters for the application
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Uncomment the following line to add a custom exception filter to the global filters collection
            //filters.Add(new MyExceptionFilter());


            // Uncomment the following line to add a global error handler filter
            // This filter handles all exceptions of type Exception and directs to the "Error" view
            //filters.Add(new HandleErrorAttribute() { ExceptionType = typeof(Exception), View = "Error" });
        }
    }
}



