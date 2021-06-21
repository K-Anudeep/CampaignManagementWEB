using Microsoft.EntityFrameworkCore;
using MarketingManagement.API.Models.Entities;

namespace MarketingManagement.API.DataContext
{
    public class MarketingMgmtDBContext : DbContext
    {
        public MarketingMgmtDBContext(DbContextOptions<MarketingMgmtDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Campaigns> Campaigns { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Leads> Leads { get; set; }

        public DbSet<Sales> Sales { get; set; }
    }
}
