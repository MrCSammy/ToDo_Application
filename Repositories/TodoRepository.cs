using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo_Application.Data;
using ToDo_Application.Models;

namespace ToDo_Application.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApiDbContext _context;

        public TodoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodosByUser(string userId)
        {
            return await _context.TodoItems.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}
