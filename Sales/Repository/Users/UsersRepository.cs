﻿using Microsoft.IdentityModel.Tokens;
using Sales.Data;
using Sales.Entities.Dtos.Users;
using Sales.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sales.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private string SecretKey;

        public UsersRepository(ApplicationDbContext context, 
            IConfiguration config)
        {
            _context = context;
            SecretKey = config.GetValue<string>("Setting:SecretKey");
        }
        public User GetUser(int UserId)
        {
            return _context.User.FirstOrDefault(u => u.Id == UserId);
        }

        public bool IsUniqueUser(string userName)
        {
            var usuarioBd = _context.User.FirstOrDefault(u => u.UserName == userName);
            if (usuarioBd == null)
            {
                return true;
            }
            return false;      
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.User.OrderBy(u => u.Name).ToList();
        }

        public async Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto)
        {
            var user = _context.User.FirstOrDefault(
                u => u.UserName ==  loginUserDto.UserName &&
                u.Password == loginUserDto.Password);

            if (user == null) 
            {
                LoginUserResponseDto? userSession = new LoginUserResponseDto()
                {
                    Token = "",
                    user = null
                };
                return userSession;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);

                LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto()
                {
                    Token = tokenHandler.WriteToken(token),
                    user = user
                };
                return loginUserResponseDto;
            }
            catch (Exception ex)
            {

                throw;
            }            
        }

        public async Task<User> Register(CreateUserDto createUserDto)
        {
            User user = new User()
            {
                Name = createUserDto.Name,
                UserName = createUserDto.UserName,
                Password = createUserDto.Password,
                Role = createUserDto.Role
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
