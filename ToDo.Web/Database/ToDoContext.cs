using Microsoft.EntityFrameworkCore;

namespace ToDo.Web;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
}
