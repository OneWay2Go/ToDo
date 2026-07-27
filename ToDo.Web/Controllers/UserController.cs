using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Web.DTOs;
using ToDo.Web.Entities;
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
            var user = await userService.GetUserByUsernameAsync(dto.Username);
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
            var user = await userService.GetUserByUsernameAsync(dto.Username);
            if(user != null)
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
            await userService.AddUserAsync(newUser);

            return Ok();
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest("There is no User with provided Id");
        }

        [HttpGet("get-by-username")]
        public async Task<ActionResult<User>> GetByUsernameAsync(string username)
        {
            var user = await userService.GetUserByUsernameAsync(username);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest("There is no User with provided Username");
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePasswordAsync(UpdateUserPasswordDTO dto)
        {
            try
            {
                await userService.UpdateUserPasswordAsync(dto);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update-username")]
        public async Task<IActionResult> UpdateUsernameAsync(UpdateUserUsernameDTO dto)
        {
            try
            {
                await userService.UpdateUserUsernameAsync(dto);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
