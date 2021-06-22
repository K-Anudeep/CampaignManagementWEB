using MarketingManagement.API.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MarketingManagement.API.DataContext;

namespace MarketingManagement.API.Models.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T: class
    {
        private readonly MarketingMgmtDBContext _context;
        private readonly DbSet<T> _dbset;

        public GenericRepo(MarketingMgmtDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public T AddRecord(T records)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public T GetRecord(object value)
        {
            throw new System.NotImplementedException();
        }

        public T UpdateRecord(object value)
        {
            throw new System.NotImplementedException();
        }
    }
}
