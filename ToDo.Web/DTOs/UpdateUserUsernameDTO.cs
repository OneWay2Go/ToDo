namespace ToDo.Web.DTOs;

public class UpdateUserUsernameDTO
{
    public string CurrentUsername { get; set; }
    public string NewUsername { get; set; }
    public string Password { get; set; }
}
