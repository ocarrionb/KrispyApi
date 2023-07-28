using Sales.Data;
using Sales.Entities.Sales;

namespace Sales.Repository.Sales
{
    public class SalesRepository : ISalesRepository
    {
        private readonly ApplicationDbContext _context;
        public SalesRepository(ApplicationDbContext context) { 
            _context = context;
        }

        public ICollection<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }
    }
}
