using Sales.Entities.Dtos.Users;
using Sales.Entities.Sales;
using Sales.Entities.Users;

namespace Sales.Repository.Sales
{
    public interface ISalesRepository
    {
        ICollection<Sale> GetAllSales();

        bool PostSale(Sale sale);
        Sale GetSale(int id);
        bool Save();
    }
}
