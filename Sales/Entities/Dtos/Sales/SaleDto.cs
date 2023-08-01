using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Sales
{
    public class SaleDto
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Direction { get; set; }

        public int Type { get; set; }

        public int Amount { get; set; }
    }
}
