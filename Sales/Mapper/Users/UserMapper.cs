using AutoMapper;
using Sales.Entities.Dtos.Users;
using Sales.Entities.Users;

namespace Sales.Mapper.Users
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<User, UserDto>();
            CreateMap<User, LoginUserResponseDto>();
        }
    }
}
