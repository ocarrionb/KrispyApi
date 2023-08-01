using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Sales.Entities.Dtos.Sales;
using Sales.Entities.Dtos.Users;
using Sales.Services.Users;

namespace Sales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsuarios()
        {
            try
            {
                var userList = _usersService.GetAllUsers();
                if (userList == null)
                {
                    return NotFound();
                }
                return Ok(userList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            bool validate = _usersService.IsUnique(createUserDto.UserName);

            if (!validate)
            {
                return StatusCode(400, "Username is already used.");
            }

            if (!ModelState.IsValid || createUserDto == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _usersService.Register(createUserDto);
                if(res == null)
                    return StatusCode(500, "Internal server error, please contact support");

                return Ok();                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid || loginUserDto == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var res = await _usersService.Login(loginUserDto);
                if (res.user == null || string.IsNullOrEmpty(res.Token))
                    return StatusCode(400, "Login not successful");

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
