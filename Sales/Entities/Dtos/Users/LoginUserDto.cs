using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Users
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "The UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        public string Password { get; set; }


    }
}
