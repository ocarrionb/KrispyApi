using Sales.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Users
{
    public class LoginUserResponseDto
    {
        public User? user { get; set; }
        
        public string Token { get; set; }
    }
}
