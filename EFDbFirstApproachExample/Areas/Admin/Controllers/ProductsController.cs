using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EFDbFirstApproachExample.Filters;
using Company.DomainModels;
using Company.DataLayer;
using Company.ServiceContracts;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFDbFirstApproachExample.Areas.Admin.Controllers
{
    [AdminAuthorization] // Apply AdminAuthorization filter to restrict access to authorized users
    public class ProductsController : Controller
    {
        private readonly CompanyDbContext db;
        IProductsService prodService;

        public ProductsController(IProductsService pService)
        {
            this.db = new CompanyDbContext();
            this.prodService = pService;
        }

        // GET: Products/Index
        public async Task<ActionResult> IndexAsync(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            ViewBag.search = search;
            // Retrieve products based on search keyword asynchronously
            List<Product> products = await prodService.SearchProducts(search);

            /* Sorting: Implement sorting logic for different columns */
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DOP).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DOP).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            /* Paging: Implement pagination logic */
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(products); // Return paginated and sorted list of products to view
        }


        // GET: Products/Details/{id}
        public async Task<ActionResult> Details(long id)
        {
            Product p = await prodService.GetProductByProductID(id); // Retrieve product details by ID asynchronously
            return View(p);  // Return product details to view
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await db.Categories.ToListAsync(); // Populate categories dropdown list
            ViewBag.Brands = await db.Brands.ToListAsync(); // Populate brands dropdown list
            return View(); // Return create product form view
        }

        // POST: Products/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "ProductID, ProductName, Price, DOP, AvailabilityStatus, CategoryID, BrandID, Active, Photo")] Product p)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;  // Convert and store product photo as base64 string
                }
                await prodService.InsertProduct(p); // Insert new product asynchronously
                return RedirectToAction("Index");  // Redirect to product list after successful creation
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList(); // Populate categories dropdown list
                ViewBag.Brands = db.Brands.ToList(); // Populate brands dropdown list
                return View(); // Return create product form with validation errors
            }
        }

        // GET: Products/Edit/{id}
        public async Task<ActionResult> Edit(long id)
        {
            Product existingProduct = await prodService.GetProductByProductID(id); // Retrieve product details by ID asynchronously
            ViewBag.Categories = db.Categories.ToListAsync(); // Populate categories dropdown list asynchronously
            ViewBag.Brands = db.Brands.ToListAsync(); // Populate brands dropdown list asynchronously
            return View(existingProduct); // Return edit product form view with existing product details
        }


        // POST: Products/Edit/{id}
        [HttpPost]
        public async Task<ActionResult> Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = await db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefaultAsync();  // Retrieve existing product from database
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    existingProduct.Photo = base64String; // Convert and update product photo as base64 string
                }

                // Update product details
                existingProduct.ProductName = p.ProductName;
                existingProduct.Price = p.Price;
                existingProduct.DOP = p.DOP;
                existingProduct.CategoryID = p.CategoryID;
                existingProduct.BrandID = p.BrandID;
                existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                existingProduct.Active = p.Active;

                await prodService.UpdateProduct(existingProduct);   // Update product asynchronously
            }
            return RedirectToAction("Index", "Products"); // Redirect to product list after successful update
        }

        // GET: Products/Delete/{id}
        public async Task<ActionResult> Delete(long id)
        {
            Product existingProduct = await prodService.GetProductByProductID(id); // Retrieve product details by ID asynchronously
            return View(existingProduct);  // Return delete confirmation view with product details
        }


        // POST: Products/Delete/{id}
        [HttpPost]
        public async Task<ActionResult> Delete(long id, Product p)
        {
           await prodService.DeleteProduct(id);  // Delete product asynchronously
            return RedirectToAction("Index", "Products");  // Redirect to product list after successful deletion
        }
    }
}



