using ToDo.Web.Entities;

namespace ToDo.Web.Services.Interfacees;

public interface ITokenProvider
{
    string Create(User user);
}
