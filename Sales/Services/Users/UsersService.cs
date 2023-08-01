using AutoMapper;
using Sales.Entities.Dtos.Users;
using Sales.Entities.Users;
using Sales.Repository.Users;
using XSystem.Security.Cryptography;

namespace Sales.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public bool IsUnique(string UserName)
        {
            return _usersRepository.IsUniqueUser(UserName);
        }


        public ICollection<UserDto> GetAllUsers()
        {
            var listUsers = _usersRepository.GetAllUsers();
            var listUsersDto = new List<UserDto>();

            foreach (var item in listUsers)
            {
                listUsersDto.Add(_mapper.Map<UserDto>(item));
            }
            return listUsersDto;
        }

        public async Task<User> Register(CreateUserDto createUserDto)
        {
            var passwordEncriptado = GetMd5(createUserDto.Password);
            createUserDto.Password = passwordEncriptado;
            return await _usersRepository.Register(createUserDto);
        }

        public async Task<LoginUserResponseDto> Login (LoginUserDto loginUserDto)
        {
            var passwordEncriptado = GetMd5(loginUserDto.Password);
            LoginUserDto user = new LoginUserDto() { 
                UserName = loginUserDto.UserName,
                Password = passwordEncriptado
            };
            return await _usersRepository.Login(user);
        }

        private static string GetMd5(string pass)
        {
            MD5CryptoServiceProvider tmp = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pass);
            data = tmp.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
