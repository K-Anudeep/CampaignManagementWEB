using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface IProductsRepo
    {
        void AddProducts(Products products);

        List<Products> DisplayProducts();

        Products OneProduct(int pId);

        void DeleteProduct(int pId);
    }
}
