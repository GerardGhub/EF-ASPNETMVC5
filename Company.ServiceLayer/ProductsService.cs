using System;
using System.Collections.Generic;
using Company.DomainModels;
using Company.RepositoryContracts;
using System.Threading.Tasks;
using Company.ServiceContracts;

namespace Company.ServiceLayer
{
    // Service layer implementation for managing product-related operations
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository prodRep;

        // Constructor to inject the repository dependency
        public ProductsService(IProductsRepository r)
        {
            this.prodRep = r;
        }

        // Retrieves all products asynchronously
        public async Task<List<Product>> GetProducts()
        {
            // Delegates the call to the repository to fetch products from the database
            return await prodRep.GetProducts();
        }

        // Searches for products by name asynchronously
        public async Task<List<Product>> SearchProducts(string ProductName)
        {
            // Delegates the call to the repository to search products based on the product name
            return await prodRep.SearchProducts(ProductName);
        }

        // Retrieves a specific product by its ID asynchronously
        public async Task<Product> GetProductByProductID(long ProductID)
        {
            // Delegates the call to the repository to fetch a product by its unique ID
            return await prodRep.GetProductByProductID(ProductID);
        }

        // Inserts a new product into the repository asynchronously
        public async Task InsertProduct(Product p)
        {
            // Checks if the price of the product is within the acceptable limit
            if (p.Price <= 1000000)
            {
                // Delegates the call to the repository to insert the new product
                await prodRep.InsertProduct(p);
            }
            else
            {
                // Throws an exception if the product price exceeds the limit
                throw new Exception("Price exceeds the limit");
            }
        }

        // Updates an existing product in the repository asynchronously
        public async Task UpdateProduct(Product p)
        {
            // Delegates the call to the repository to update the product details
            await prodRep.UpdateProduct(p);
        }

        // Deletes a product from the repository by its ID asynchronously
        public async Task DeleteProduct(long ProductID)
        {
            // Delegates the call to the repository to delete the product by its ID
            await prodRep.DeleteProduct(ProductID);
        }
    }
}


