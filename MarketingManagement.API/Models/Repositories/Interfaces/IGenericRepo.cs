using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    interface IGenericRepo<T> where T: class
    {
        T AddRecord(T records);

        T GetRecord(object value);

        IEnumerable<T> GetAllRecords();

        T UpdateRecord(object value);
    }
}
