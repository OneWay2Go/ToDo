namespace ToDo.Web;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime WhenToDo { get; set; }
    public bool IsDone { get; set; } = false;

    public User User { get; set; }
}
