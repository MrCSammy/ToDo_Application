using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo_Application.Data;
using ToDo_Application.Models;
using ToDo_Application.Repositories;
namespace ToDo_Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
