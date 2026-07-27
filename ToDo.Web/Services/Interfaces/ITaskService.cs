using ToDo.Web.DTOs;

namespace ToDo.Web.Services.Interfacees;

public interface ITaskService
{
    Task AddTask(AddTaskDTO dto);
    Task<IList<Entities.Task>> GetTasks();
    Task<Entities.Task> GetTaskById(int id);
    Task UpdateTaskName(UpdateTaskNameDTO dto);
    Task UpdateTaskTime(UpdateTaskTimeDTO dto);
    Task CompleteTask(int id);
    Task UncompleteTask(int id);
    Task DeleteTask(int id);
}
