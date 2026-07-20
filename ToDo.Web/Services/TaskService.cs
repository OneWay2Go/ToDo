
using Microsoft.EntityFrameworkCore;

namespace ToDo.Web;

public class TaskService(ToDoContext context) : ITaskService
{
    public async System.Threading.Tasks.Task AddTask(AddTaskDTO dto)
    {
        var task = new Task()
        {
            Name = dto.Name,
            WhenToDo = dto.WhenToDo
        };

        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task CompleteTask(int id)
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

    public async System.Threading.Tasks.Task DeleteTask(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
        throw new ArgumentException("There is no Task with provided Id");
    }

    public async Task<Task> GetTaskById(int id)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task != null)
        {
            return task;
        }
        throw new ArgumentException("There is no Task with provided Id");
    }

    public async Task<IList<Task>> GetTasks()
    {
        List<Task> tasks = await context.Tasks.ToListAsync();
        return tasks;
    }

    public async System.Threading.Tasks.Task UncompleteTask(int id)
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

    public async System.Threading.Tasks.Task UpdateTaskName(UpdateTaskNameDTO dto)
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

    public async System.Threading.Tasks.Task UpdateTaskTime(UpdateTaskTimeDTO dto)
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
