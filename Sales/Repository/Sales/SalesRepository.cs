using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        public bool PostSale(Sale sale)
        {
            _context.Sales.Add(sale);
            return Save();
        }

        public Sale GetSale(int id)
        {
            return _context.Sales.FirstOrDefault(c => c.Id == id);
        }
        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
