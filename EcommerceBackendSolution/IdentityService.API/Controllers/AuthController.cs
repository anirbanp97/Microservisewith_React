using IdentityService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await _userService.RegisterAsync(username, password);
            return result ? Ok("User registered.") : BadRequest("Failed.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _userService.LoginAsync(username, password);
            return token != null ? Ok(token) : Unauthorized();
        }
    }
}
