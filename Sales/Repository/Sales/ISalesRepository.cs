using Sales.Entities.Sales;

namespace Sales.Repository.Sales
{
    public interface ISalesRepository
    {
        public ICollection<Sale> GetAllSales();
    }
}
