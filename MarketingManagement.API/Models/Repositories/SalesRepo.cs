using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;
using MarketingManagement.API.Models.Repositories.Interfaces;
using MarketingManagement.API.DataContext;
using System.Linq;

namespace MarketingManagement.API.Models.Repositories
{
    public class SalesRepo : ISalesRepo
    {
        private readonly MarketingMgmtDbContext _context;

        public SalesRepo(MarketingMgmtDbContext context)
        {
            _context = context;
        }
        public bool CreateSales(Sales sales)
        {
            _context.Sales.Add(sales);
            _context.SaveChanges();
            return true;

        }

        public List<Sales> ViewSales()
        {
            return _context.Sales.ToList();
        }
    }
}