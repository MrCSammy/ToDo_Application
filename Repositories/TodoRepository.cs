using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<TodoItem>> GetTodos(int userId)
        {
            return await _context.TodoItems.Where(user_id => user_id.UserId == userId).ToListAsync();
        }

        public async Task<TodoItem> AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }
    }
}
