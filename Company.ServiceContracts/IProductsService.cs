using System.Collections.Generic;
using System.Threading.Tasks;
using Company.DomainModels;

namespace Company.ServiceContracts
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> SearchProducts(string ProductName);
        Task<Product> GetProductByProductID(long ProductID);
        void InertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(long ProductID);
    }
}



