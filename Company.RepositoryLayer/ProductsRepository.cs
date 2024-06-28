using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.RepositoryContracts;
using Company.DomainModels;
using Company.DataLayer;
using System.Data.Entity;

namespace Company.RepositoryLayer
{
    public class ProductsRepository: IProductsRepository
    {
        CompanyDbContext db;

        public ProductsRepository()
        {
            this.db = new CompanyDbContext();
        }


 

        public Product GetProductByProductID(long ProductID)
        {
            Product p = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            return p;
        }
        public void InsertProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }
        public void UpdateProduct(Product p)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DOP = p.DOP;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Photo = p.Photo;
            db.SaveChanges();
        }
        public void DeleteProduct(long ProductID)
        {
            Product existingProduct = db.Products.Where(temp => temp.ProductID == ProductID).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }



        public async Task<List<Product>> SearchProducts(string ProductName)
        {
            return await db.Products
               .Where(p => p.ProductName.Contains(ProductName))
               .ToListAsync();
        }
    }
}



