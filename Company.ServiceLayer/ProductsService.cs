using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.ServiceContracts;
using Company.DataLayer;
using Company.DomainModels;
using Company.RepositoryContracts;
using Company.RepositoryLayer;
using System.Threading.Tasks;

namespace Company.ServiceLayer
{
    public class ProductsService : IProductsService
    {
        IProductsRepository prodRep;

        public ProductsService(IProductsRepository r)
        {
            this.prodRep = r;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await prodRep.GetProducts();
        }

        //public List<Product> SearchProducts(string ProductName)
        //{
        //    List<Product> products = prodRep.SearchProducts(ProductName);
        //    return products;
        //}

        public Product GetProductByProductID(long ProductID)
        {
            Product p = prodRep.GetProductByProductID(ProductID);
            return p;
        }
        public void InertProduct(Product p)
        {
            if (p.Price <= 1000000)
            {
                prodRep.InsertProduct(p);
            }
            else
            {
                throw new Exception("Price exceeds the limit");
            }
        }
        public void UpdateProduct(Product p)
        {
            prodRep.UpdateProduct(p);
        }
        public void DeleteProduct(long ProductID)
        {
            prodRep.DeleteProduct(ProductID);
        }

        public async Task<List<Product>> SearchProducts(string ProductName)
        {
            return await prodRep.SearchProducts(ProductName);
        }
    }
}


