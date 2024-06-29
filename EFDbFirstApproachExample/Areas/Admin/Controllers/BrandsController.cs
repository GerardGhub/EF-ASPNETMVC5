using System.Collections.Generic;
using System.Web.Mvc;
using Company.DomainModels; // Assuming DomainModels namespace contains Brand class
using EFDbFirstApproachExample.Filters; // Custom AdminAuthorization filter
using Company.DataLayer;
using System.Threading.Tasks;
using System.Data.Entity; // Assuming CompanyDbContext is defined in this namespace

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization] // Applying AdminAuthorization filter to secure access
    public class BrandsController : Controller
    {
        // GET: Brands/Index
        public async Task<ActionResult> Index()
        {
            // Creating an instance of CompanyDbContext to interact with the database
            CompanyDbContext db = new CompanyDbContext();

            // Retrieving all brands from the database
            List<Brand> brands = await db.Brands.ToListAsync();

            // Returning a view with the list of brands as the model
            return View(brands);
        }
    }
}


