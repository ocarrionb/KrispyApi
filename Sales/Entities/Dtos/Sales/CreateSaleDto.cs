using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Sales
{
    public class CreateSaleDto
    {
        [Required(ErrorMessage = "The UserName is required")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters exceeded")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Direction is required")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters exceeded")]
        public string Direction { get; set; }

        [Required(ErrorMessage = "The Type is required")]
        [Range(1, 7, ErrorMessage = "Donut type does not exist")]
        public int Type { get; set; } = 0;

        [Required(ErrorMessage = "The Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Amount { get; set; } = 0;
    }
}
