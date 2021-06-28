using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.DataContext;
using System.Linq;

namespace MarketingManagement.API.Models.Repositories
{
    public class ProductRepo : IProductsRepo
    {
        private readonly MarketingMgmtDbContext _context;

        public ProductRepo(MarketingMgmtDbContext context)
        {
            _context = context;
        }

        public void AddProducts(Products products)
        {          
            _context.Products.Add(products);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int productId)
        {            
            _context.Remove(productId);
            _context.SaveChanges();
            return true;
        }

        public List<Products> DisplayProducts()
        {
            return _context.Products.ToList();
        }

        public Products OneProduct(int productId)
        {
            return _context.Products.Find(productId);
        }
    }
}