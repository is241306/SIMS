using api.DTOs.Users;
using api.DTOs.Authentication;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _authService.RegisterAsync(dto);
            if (!success)
                return BadRequest("Failed to register user");

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto) {
            var result = await _authService.LoginAsync(dto);
            
            if(result == null)
                return Unauthorized("Invalid username or password");
            
            return Ok(result);
        }
    }
}
