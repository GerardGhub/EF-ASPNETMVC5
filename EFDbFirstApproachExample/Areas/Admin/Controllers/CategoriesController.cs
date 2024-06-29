using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters; // Assuming AdminAuthorization filter is defined here
using Company.DomainModels; // Assuming DomainModels namespace contains Category class
using Company.DataLayer;
using System.Data.Entity;
using System.Threading.Tasks; // Assuming CompanyDbContext is defined in this namespace

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization] // Applying AdminAuthorization filter to secure access
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public async Task<ActionResult> Index()
        {
            using (CompanyDbContext db = new CompanyDbContext())
            {
                // Retrieve all categories from the database
                List<Category> categories = await db.Categories.ToListAsync();

                // Return a view with the list of categories as the model
                return View(categories);
            }
        }
    }
}
