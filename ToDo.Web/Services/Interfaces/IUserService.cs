using ToDo.Web.DTOs;
using ToDo.Web.Entities;

namespace ToDo.Web.Services.Interfacees;

public interface IUserService
{
    System.Threading.Tasks.Task AddUser(AddUserDTO dto);
    Task<IList<User>> GetUsers();
    Task<User> GetUserById(int id);
    Task<User> GetUserByUsername(string username);
    System.Threading.Tasks.Task UpdateUserUsername(UpdateUserUsernameDTO dto);
    System.Threading.Tasks.Task UpdateUserPassword(UpdateUserPasswordDTO dto);
    System.Threading.Tasks.Task DeleteUser(string username);
}
