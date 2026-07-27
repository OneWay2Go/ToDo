using Microsoft.EntityFrameworkCore;
using ToDo.Web.DTOs;
using ToDo.Web.Services.Interfacees;
using ToDo.Web.Database;

namespace ToDo.Web.Services;

public class TaskService(ToDoContext context) : ITaskService
{
    public async Task AddTask(AddTaskDTO dto)
    {
        var task = new Entities.Task()
        {
            Name = dto.Name,
            WhenToDo = dto.WhenToDo
        };

        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async Task CompleteTask(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null)
        {
            task.IsDone = true;

            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id");
    }

    public async Task DeleteTask(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id");
    }

    public async Task<Entities.Task> GetTaskById(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null)
        {
            return task;
        }
        throw new ArgumentException("There is no Task with provided Id");
    }

    public async Task<IList<Entities.Task>> GetTasks()
    {
        List<Entities.Task> tasks = await context.Tasks.ToListAsync();
        return tasks;
    }

    public async Task UncompleteTask(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.IsDone == false);
        if (task != null)
        {
            task.IsDone = false;

            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id or Task is already uncomleted");
    }

    public async Task UpdateTaskName(UpdateTaskNameDTO dto)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == dto.Id && t.Name != dto.NewName);
        if (task != null)
        {
            task.Name = dto.NewName;

            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id or New Task Name is not new");
    }

    public async Task UpdateTaskTime(UpdateTaskTimeDTO dto)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == dto.Id && t.WhenToDo != dto.NewTime);
        if (task != null)
        {
            task.WhenToDo = dto.NewTime;

            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id or NewTime is not new");
    }
}
