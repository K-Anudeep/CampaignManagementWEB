using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface IProductsRepo
    {
        bool AddProducts(Products products);

        List<Products> DisplayProducts();

        Products OneProduct(int pId);

        bool DeleteProduct(int pId);
    }
}
