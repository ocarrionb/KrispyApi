using Sales.Entities.Sales;

namespace Sales.Services.Sales
{
    public interface ISalesService
    {
        ICollection<Sale> GetAllSales();
    }
}
