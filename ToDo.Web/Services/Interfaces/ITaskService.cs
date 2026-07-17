namespace ToDo.Web;

public interface ITaskService
{
    System.Threading.Tasks.Task AddTask(AddTaskDTO dto);
    IList<Task> GetTasks();
    Task<Task> GetTaskById(int id);
    Task<Task> GetTaskByName(string name);
    System.Threading.Tasks.Task UpdateTaskName(UpdateTaskNameDTO dto);
    System.Threading.Tasks.Task UpdateTaskTime(UpdateTaskTimeDTO dto);
    System.Threading.Tasks.Task CompleteTask(int id);
    System.Threading.Tasks.Task UncompleteTask(int id);
    System.Threading.Tasks.Task DeleteTask(int id);
}
