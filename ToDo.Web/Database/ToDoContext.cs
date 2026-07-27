using Microsoft.EntityFrameworkCore;
using ToDo.Web.Entities;

namespace ToDo.Web.Database;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Entities.Task> Tasks { get; set; }
}
