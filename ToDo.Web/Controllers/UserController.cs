using Microsoft.AspNetCore.Mvc;
using ToDo.Web.DTOs;
using ToDo.Web.Services.Interfacees;

namespace ToDo.Web.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController(IUserService userService, ITokenProvider tokenProvider) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await userService.GetUserByUsername(dto.Username);
            if(user == null)
            {
                return BadRequest("User does not exist");
            }
            
            if(user.Password != dto.Password)
            {
                return BadRequest("Double check your password bro");
            }

            var token = tokenProvider.Create(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var user = await userService.GetUserByUsername(dto.Username);
            if(user.Username != null)
            {
                return BadRequest("Username exists");
            }

            if(dto.Password != dto.ReTypePassword)
            {
                return BadRequest("Passwords do not match");
            }

            var newUser = new AddUserDTO()
            {
                Username = dto.Username,
                Password = dto.Password
            };
            await userService.AddUser(newUser);

            return Ok();
        }
    }
}
