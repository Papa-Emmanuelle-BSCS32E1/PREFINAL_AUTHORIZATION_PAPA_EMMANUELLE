using AuthServer.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthServer.Core.Models;
namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = await _userService.RegisterAsync(model.Username, model.Password);
            if (user == null) return BadRequest("User already exists");
            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userService.LoginAsync(model.Username, model.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
