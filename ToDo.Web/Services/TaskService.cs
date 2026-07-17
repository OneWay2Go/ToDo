
namespace ToDo.Web;

public class TaskService(ToDoContext context) : ITaskService
{
    public System.Threading.Tasks.Task AddTask(AddTaskDTO dto)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task CompleteTask(int id)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task DeleteTask(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Task> GetTaskById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Task> GetTaskByName(string name)
    {
        throw new NotImplementedException();
    }

    public IList<Task> GetTasks()
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task UncompleteTask(int id)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task UpdateTaskName(UpdateTaskNameDTO dto)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task UpdateTaskTime(UpdateTaskTimeDTO dto)
    {
        throw new NotImplementedException();
    }
}
