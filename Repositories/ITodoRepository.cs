using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo_Application.Models;

namespace ToDo_Application.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodosByUser(string userId);
        Task AddTodoItem(TodoItem todoItem);
    }
}
