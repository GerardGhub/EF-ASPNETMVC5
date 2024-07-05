using System.Collections.Generic;
using System.Threading.Tasks; // Required for asynchronous operations
using Company.DomainModels; // Assuming DomainModels namespace contains Product class


namespace Company.RepositoryContracts
{
    // Interface defining repository operations for products
    public interface IProductsRepository
    {
        // Retrieves all products from the repository asynchronously
        Task<List<Product>> GetProducts();

        // Searches products by product name asynchronously
        Task<List<Product>> SearchProducts(string ProductName);

        // Retrieves a product by its unique ProductID asynchronously
        Task<Product> GetProductByProductID(long ProductID);

        // Inserts a new product into the repository
        Task InsertProduct(Product p);  

        // Updates an existing product in the repository asynchronously
        Task UpdateProduct(Product p);

        // Deletes a product from the repository by its ProductID asynchronously
        Task DeleteProduct(long ProductID);
    }
}



