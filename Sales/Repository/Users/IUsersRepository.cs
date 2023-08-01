using Sales.Entities.Dtos.Users;
using Sales.Entities.Users;

namespace Sales.Repository.Users
{
    public interface IUsersRepository
    {
        ICollection<User> GetAllUsers();

        User GetUser(int UserId);

        bool IsUniqueUser(string userName);

        Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto);


        Task<User> Register(CreateUserDto createUserDto);
    }
}
