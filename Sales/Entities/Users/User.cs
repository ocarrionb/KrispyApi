using System.ComponentModel.DataAnnotations;

namespace Sales.Entities.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
