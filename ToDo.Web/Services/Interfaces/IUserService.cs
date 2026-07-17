namespace ToDo.Web;

public interface IUserService
{
    System.Threading.Tasks.Task AddUser(AddUserDTO dto);
    IList<User> GetUsers();
    Task<User> GetUserById(int id);
    Task<User> GetUserByUsername(string username);
    System.Threading.Tasks.Task UpdateUserUsername(UpdateUserUsernameDTO dto);
    System.Threading.Tasks.Task UpdateUserPassword(UpdateUserPasswordDTO dto);
    System.Threading.Tasks.Task DeleteUser(string username);
}
