using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo_Application.Models;
namespace ToDo_Application.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodos(int userId);
        Task<TodoItem> AddTodoItem(TodoItem todoItem);
    }
}
