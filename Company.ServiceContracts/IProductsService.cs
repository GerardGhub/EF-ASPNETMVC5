using System.Collections.Generic;
using System.Threading.Tasks;
using Company.DomainModels;  // Assuming DomainModels namespace contains the Product class

namespace Company.ServiceContracts
{
    // Interface defining service operations for products
    public interface IProductsService
    {
        // Retrieves all products asynchronously
        Task<List<Product>> GetProducts();
        // Searches for products by name asynchronously
        Task<List<Product>> SearchProducts(string ProductName);
        // Retrieves a product by its unique ProductID asynchronously
        Task<Product> GetProductByProductID(long ProductID);
        // Inserts a new product asynchronously
        Task InsertProduct(Product p);
        // Updates an existing product asynchronously
        Task UpdateProduct(Product p);
        // Deletes a product by its ProductID asynchronously
        Task DeleteProduct(long ProductID);
    }
}



