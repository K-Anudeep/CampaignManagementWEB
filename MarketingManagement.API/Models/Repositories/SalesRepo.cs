using System;
using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarketingManagement.API.Models.Repositories
{
    public class SalesRepo : ISalesRepo
    {
        private readonly MarketingMgmtDBContext _context;

        public SalesRepo(MarketingMgmtDBContext context)
        {
            _context = context;
        }
        public void  CreateSales(Sales sales)
        {
            _context.Sales.Add(sales);
            _context.SaveChanges();
        }

        public List<Sales> ViewSales()
        {
            return _context.Sales.ToList();
        }
    }
}