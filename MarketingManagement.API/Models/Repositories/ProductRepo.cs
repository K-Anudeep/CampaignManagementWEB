using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using System.Data;
using DatabaseLayer.DBException;
using MarketingManagement.API.DataContext;
using System;
using System.Linq;

namespace MarketingManagement.API.Models.Repositories
{
    public class ProductRepo : IProductsRepo
    {
        private readonly MarketingMgmtDBContext _context;

        public ProductRepo(MarketingMgmtDBContext context)
        {
            _context = context;
        }

        public void AddProducts(Products products)
        {
          
            _context.Products.Add(products);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int pId)
        {
            
            _context.Remove(pId);
            _context.SaveChanges();
            return true;
        }

        public List<Products> DisplayProducts()
        {
            return _context.Products.ToList();
        }

        public Products OneProduct(int pId)
        {
            return _context.Products.Find(pId);
        }
    }
}