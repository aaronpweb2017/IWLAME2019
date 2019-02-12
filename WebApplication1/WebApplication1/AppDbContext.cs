using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}