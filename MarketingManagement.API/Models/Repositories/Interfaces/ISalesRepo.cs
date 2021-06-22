using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ISalesRepo
    {
        void CreateSales(Sales sales);

        List<Sales> ViewSales();
    }
}
