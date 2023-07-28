using Microsoft.EntityFrameworkCore;
using Sales.Entities.Sales;

namespace Sales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; } = default!;
    }
}
