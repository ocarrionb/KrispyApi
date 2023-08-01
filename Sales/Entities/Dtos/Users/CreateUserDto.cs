using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Users
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "The UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        public string Password { get; set; }


    }
}
