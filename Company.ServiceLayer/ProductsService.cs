﻿using System;
using System.Collections.Generic;
using Company.ServiceContracts;
using Company.DomainModels;
using Company.RepositoryContracts;
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


        //public void InertProduct(Product p)
        //{
        //    if (p.Price <= 1000000)
        //    {
        //        prodRep.InsertProduct(p);
        //    }
        //    else
        //    {
        //        throw new Exception("Price exceeds the limit");
        //    }
        //}
        //public void UpdateProduct(Product p)
        //{
        //    prodRep.UpdateProduct(p);
        //}
        //public void DeleteProduct(long ProductID)
        //{
        //    prodRep.DeleteProduct(ProductID);
        //}

        public async Task<List<Product>> SearchProducts(string ProductName)
        {
            return await prodRep.SearchProducts(ProductName);
        }

        public async Task<Product> GetProductByProductID(long ProductID)
        {
            return await prodRep.GetProductByProductID(ProductID);
        }

        public async Task InsertProduct(Product p)
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

        public Task UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(long ProductID)
        {
            throw new NotImplementedException();
        }
    }
}


