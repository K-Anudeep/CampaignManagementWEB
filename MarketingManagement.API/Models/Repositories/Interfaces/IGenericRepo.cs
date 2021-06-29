using System.Collections.Generic;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    internal interface IGenericRepo<T> where T : class
    {
        void AddRecord(T records);

        T GetRecord(object value);

        IEnumerable<T> GetAllRecords();

        void DeleteRecord(object value);

        bool UpdateRecord(T value);
    }
}