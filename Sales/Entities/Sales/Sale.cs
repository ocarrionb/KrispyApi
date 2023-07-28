using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Sales
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Direction { get; set; }

        public int? Type { get; set; }

        public int? Amount { get; set; }
    }
}
