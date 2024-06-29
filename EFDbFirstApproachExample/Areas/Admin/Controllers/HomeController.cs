using EFDbFirstApproachExample.Filters;
using System.Web.Mvc;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}


