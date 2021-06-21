using System.Collections.Generic;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.Models.Repositories.Interfaces
{
    public interface ISalesRepo
    {
        bool CreateSales(Sales sales);

        List<Sales> ViewSales();
    }
}
