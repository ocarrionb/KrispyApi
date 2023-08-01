using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Dtos.Users
{
    public class UserDto
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
