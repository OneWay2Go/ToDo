using Microsoft.EntityFrameworkCore;
using ToDo.Web.Database;
using ToDo.Web.DTOs;
using ToDo.Web.Entities;
using ToDo.Web.Services.Interfacees;

namespace ToDo.Web.Services;

public class UserService(ToDoContext context) : IUserService
{
    public async System.Threading.Tasks.Task AddUser(AddUserDTO dto)
    {
        var user = new User()
        {
            Username = dto.Username,
            Password = dto.Password
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteUser(string username)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if(user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if(user != null)
        {
            return user;
        }
        return user;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if(user != null)
        {
            return user;
        }
        return user;
    }

    public async Task<IList<User>> GetUsers()
    {
        List<User> users = await context.Users.ToListAsync();
        return users;
    }

    public async System.Threading.Tasks.Task UpdateUserPassword(UpdateUserPasswordDTO dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
        if (user != null)
        {
            if(user.Password == dto.CurrentPassword)
            {
                user.Password = dto.NewPassword;

                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            throw new ArgumentException(nameof(dto.CurrentPassword), "Provided Current Password is invalid");
        }
        throw new ArgumentException(nameof(dto.Username), "There is no User with provided Username");
    }
    public async System.Threading.Tasks.Task UpdateUserUsername(UpdateUserUsernameDTO dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == dto.CurrentUsername);
        if (user != null)
        {
            if(user.Username == dto.CurrentUsername)
            {
                user.Username = dto.NewUsername;

                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            throw new ArgumentException(nameof(dto.CurrentUsername), "Provided current username is invalid");
        }
        throw new ArgumentException(nameof(dto.CurrentUsername), "There is no User with provided Username");
    }
}
