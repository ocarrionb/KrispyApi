using Sales.Entities.Dtos.Users;
using Sales.Entities.Users;

namespace Sales.Services.Users
{
    public interface IUsersService
    {
        ICollection<UserDto> GetAllUsers();
        Task<User> Register(CreateUserDto createUserDto);
        Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto);
        bool IsUnique(string UserName);
    }
}
