using ToDo.Web.DTOs;
using ToDo.Web.Entities;

namespace ToDo.Web.Services.Interfacees;

public interface IUserService
{
    System.Threading.Tasks.Task AddUserAsync(AddUserDTO dto);
    Task<IList<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    System.Threading.Tasks.Task UpdateUserUsernameAsync(UpdateUserUsernameDTO dto);
    System.Threading.Tasks.Task UpdateUserPasswordAsync(UpdateUserPasswordDTO dto);
    System.Threading.Tasks.Task DeleteUserAsync(int id);
}
