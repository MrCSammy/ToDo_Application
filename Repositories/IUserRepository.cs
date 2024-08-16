using System.Threading.Tasks;
using ToDo_Application.Models;

namespace ToDo_Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
        Task AddUser(User user);
    }
}
