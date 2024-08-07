using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo_Application.Models;
using ToDo_Application.Repositories;

namespace ToDo_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<TodoItem>> GetTodos(int userId)
        {
            return await _todoRepository.GetTodos(userId);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoItem([FromBody] TodoItem todoItem)
        {
            var createdTodoItem = await _todoRepository.AddTodoItem(todoItem);
            return CreatedAtAction(nameof(GetTodos), new { userId = createdTodoItem.UserId }, createdTodoItem);
        }
    }
}
