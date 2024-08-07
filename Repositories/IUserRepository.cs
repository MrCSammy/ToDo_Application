using System.Threading.Tasks;
using ToDo_Application.Models;

namespace ToDo_Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}
