using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using System.Data;
using DatabaseLayer.DBException;

namespace MarketingManagement.API.Models.Repositories
{
    public class ProductRepo : IProductsRepo
    {
        public bool AddProducts(Products products)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int pId)
        {
            throw new NotImplementedException();
        }

        public List<Products> DisplayProducts()
        {
            throw new NotImplementedException();
        }

        public Products OneProduct(int pId)
        {
            throw new NotImplementedException();
        }
    }
}