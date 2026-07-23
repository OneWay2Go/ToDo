namespace ToDo.Web;

public interface ITokenProvider
{
    string Create(User user);
}
