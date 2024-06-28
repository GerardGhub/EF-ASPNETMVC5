using System.Collections.Generic;
using Company.DomainModels; // Assuming DomainModels namespace contains Product class


namespace Company.RepositoryContracts
{
    // Interface defining repository operations for products
    public interface IProductsRepository
    {
        // Retrieves all products from the repository
        List<Product> GetProducts();

        // Searches products by product name
        List<Product> SearchProducts(string ProductName);

        // Retrieves a product by its unique ProductID
        Product GetProductByProductID(long ProductID);

        // Inserts a new product into the repository
        void InsertProduct(Product p);  // Note: Typo in "InertProduct", should be "InsertProduct"

        // Updates an existing product in the repository
        void UpdateProduct(Product p);

        // Deletes a product from the repository by its ProductID
        void DeleteProduct(long ProductID);
    }
}



