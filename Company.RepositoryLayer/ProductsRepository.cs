using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.RepositoryContracts; // Contains IProductsRepository interface
using Company.DomainModels; // Contains Product class
using Company.DataLayer; // Contains CompanyDbContext class
using System.Data.Entity;

namespace Company.RepositoryLayer
{
    // Implements the IProductsRepository interface to manage product data
    public class ProductsRepository: IProductsRepository
    {
        private readonly CompanyDbContext db;

        // Constructor initializes the DbContext
        public ProductsRepository()
        {
            this.db = new CompanyDbContext();
        }


        // Asynchronously retrieves all products from the database
        public async Task<List<Product>> GetProducts()
        {
            return await db.Products.ToListAsync(); // Converts DbSet to List asynchronously
        }

        // Asynchronously searches for products by name
        public async Task<List<Product>> SearchProducts(string ProductName)
        {
            return await db.Products
               .Where(p => p.ProductName.Contains(ProductName)) // Filters products by name
               .ToListAsync(); // Converts filtered result to List asynchronously
        }

        // Asynchronously retrieves a product by its unique ProductID
        public async Task<Product> GetProductByProductID(long ProductID)
        {                         
            return await db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefaultAsync();          
        }

        //// Inserts a new product into the database asynchronously
        public async Task InsertProduct(Product p)
        {
            db.Products.Add(p); // Adds the product to the DbSet
            await db.SaveChangesAsync(); // Saves changes to the database
        }

        // Updates an existing product in the database
        public async Task UpdateProduct(Product p)
        {
            // Finds the product by ProductID
            Product existingProduct = await db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefaultAsync();

            // Updates the product properties
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DOP = p.DOP;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Photo = p.Photo;
          await  db.SaveChangesAsync(); // Saves changes to the database
        }

        // Deletes a product from the database by ProductID
        public async Task DeleteProduct(long ProductID)
        {
            // Finds the product by ProductID
            Product existingProduct = await db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefaultAsync();
            db.Products.Remove(existingProduct); // Removes the product from the DbSet
           await db.SaveChangesAsync(); // Saves changes to the database
        }
    }
}



