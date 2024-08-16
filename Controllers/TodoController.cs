using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo_Application.Models;
using ToDo_Application.Repositories;

namespace ToDo_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTodos(string userId)
        {
            var todos = await _todoRepository.GetTodosByUser(userId);
            return Ok(todos);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoRepository.AddTodoItem(todoItem);
            return CreatedAtAction(nameof(GetTodos), new { userId = todoItem.UserId }, todoItem);
        }
    }
}
