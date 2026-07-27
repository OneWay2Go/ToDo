namespace ToDo.Web.DTOs;

public class UpdateUserPasswordDTO
{
    public string Username { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
