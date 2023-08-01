using Microsoft.EntityFrameworkCore;
using Sales.Entities.Sales;
using Sales.Entities.Users;

namespace Sales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
    }
}
