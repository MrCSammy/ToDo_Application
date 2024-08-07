using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo_Application.Models;
using ToDo_Application.Repositories;

namespace ToDo_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var authenticatedUser = await _userRepository.Authenticate(user.Username, user.Password);
            if (authenticatedUser == null)
                return Unauthorized();

            return Ok(authenticatedUser);
        }
    }
}
