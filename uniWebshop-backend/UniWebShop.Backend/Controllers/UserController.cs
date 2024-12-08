using UniWebShop.Backend.DTOs;
using UniWebShop.Backend.Services;
using UniWebShop.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace UniWebShop.Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService myUserService;

        public UserController(UserService userService)
        {
            myUserService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await myUserService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {
            return await myUserService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync([FromBody] RegisterUserDTO registerUserDTO)
        {
            await myUserService.AddAsync(registerUserDTO);
        }
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ValidateUser([FromBody] LoginDTO loginDTO)
        {
            if ((loginDTO.UserName.IsNullOrEmpty() && loginDTO.Email.IsNullOrEmpty()) || loginDTO.Password.IsNullOrEmpty())
            {
                return BadRequest(loginDTO);
            }
            UserDTO? userDTO = await myUserService.ValidateUser(loginDTO);
            return userDTO is null
                ? Unauthorized()
                : Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task RemoveAsync(Guid id)
        {
            await myUserService.RemoveByIdAsync(id);
        }
        [HttpPut]
        public async Task UpdateAsync([FromBody] User user)
        {
            await myUserService.UpdateAsync(user);
        }
    }
}
