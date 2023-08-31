using Microsoft.EntityFrameworkCore;

namespace FnacDarty.JobInterview.Stock.Data
{
    public class SolidContext : DbContext
    {
        public SolidContext(DbContextOptions<SolidContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
