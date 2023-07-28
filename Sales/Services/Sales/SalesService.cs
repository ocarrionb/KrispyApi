using Sales.Entities.Sales;
using Sales.Repository.Sales;

namespace Sales.Services.Sales
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        public SalesService(ISalesRepository salesRepository) {
            _salesRepository = salesRepository;
        }

        public ICollection<Sale> GetAllSales()
        {
            return _salesRepository.GetAllSales();
        }
    }
}
