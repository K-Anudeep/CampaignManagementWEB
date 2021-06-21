using Microsoft.EntityFrameworkCore;

namespace MarketingManagement.API.DataContext
{
    public class MarketingMgmtDBContext : DbContext
    {
        public MarketingMgmtDBContext(DbContextOptions<MarketingMgmtDBContext> options) : base(options)
        {
        }
    }
}
