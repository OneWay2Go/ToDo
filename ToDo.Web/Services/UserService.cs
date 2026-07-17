namespace ToDo.Web;

public class UserService(ToDoContext context) : IUserService
{
    public System.Threading.Tasks.Task AddUser(AddUserDTO dto)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task DeleteUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public IList<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task UpdateUserPassword(UpdateUserPasswordDTO dto)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task UpdateUserUsername(UpdateUserUsernameDTO dto)
    {
        throw new NotImplementedException();
    }
}
