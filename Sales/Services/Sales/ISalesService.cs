using Sales.Entities.Dtos.Sales;
using Sales.Entities.Sales;

namespace Sales.Services.Sales
{
    public interface ISalesService
    {
        /// <summary>
        /// Get all sales.
        /// </summary>
        /// <returns></returns>
        ICollection<SaleDto> GetAllSales();
        /// <summary>
        /// Add new sale.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        bool PostSale(CreateSaleDto sale);
        /// <summary>
        /// Get an specific sale.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SaleDto GetSale(int id);

    }
}
