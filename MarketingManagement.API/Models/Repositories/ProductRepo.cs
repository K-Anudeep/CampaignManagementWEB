using System;
using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using System.Data;
using DatabaseLayer.DBException;
using MarketingManagement.API.DataContext;
<<<<<<< Updated upstream
using System;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes
using System.Linq;

namespace MarketingManagement.API.Models.Repositories
{
    public class ProductRepo : IProductsRepo
    {
<<<<<<< Updated upstream
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
=======
            private readonly MarketingMgmtDBContext _context;

            public ProductRepo(MarketingMgmtDBContext context)
            {
                _context = context;
            }

            public void AddProducts(Products products)
            {
                 _context.Add(products);
                 _context.SaveChanges();
            }
>>>>>>> Stashed changes

        public void DeleteProduct(int pId)
        {
<<<<<<< Updated upstream
            
            _context.Remove(pId);
            _context.SaveChanges();
            return true;
=======
            Products products = _context.Products.Find(pId);
            _context.Products.Remove(products);
            _context.SaveChanges();
>>>>>>> Stashed changes
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