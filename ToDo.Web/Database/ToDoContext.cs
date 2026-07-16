using Microsoft.EntityFrameworkCore;

namespace ToDo.Web;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}

    DbSet<User> Users { get; set; }
    DbSet<Task> Tasks { get; set; }
}
