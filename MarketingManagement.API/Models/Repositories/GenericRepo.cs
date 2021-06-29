using System.Collections.Generic;
using MarketingManagement.API.DataContext;
using MarketingManagement.API.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketingManagement.API.Models.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly MarketingMgmtDbContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepo(MarketingMgmtDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public void AddRecord(T records)
        {
            _dbset.Add(records);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllRecords()
        {
            return _dbset;
        }

        public T GetRecord(object value)
        {
            return _dbset.Find(value);
        }

        public bool UpdateRecord(T value)
        {
            _dbset.Update(value);
            _context.SaveChanges();
            return true;
        }

        public void DeleteRecord(object value)
        {
            var record = _dbset.Find(value);
            _dbset.Remove(record);
            _context.SaveChanges();
        }
    }
}