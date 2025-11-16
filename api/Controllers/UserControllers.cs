using api.API.DTOs.Users;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SimsContext _context;

        public UsersController(SimsContext context)
        {
            _context = context;
        }

        // GET /Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var result = users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Username = u.Username,
                // do NOT return real password – leave empty or remove this property from the DTO
                Password = string.Empty,
                IsActive = u.IsActive ? "true" : "false"
            });

            return Ok(result);
        }

        // POST /Users  (register/create user)
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> AddUser(RegisterDto dto)
        {
            // map DTO -> domain entity
            var user = new User
            {
                Username = dto.Username,
                // TODO: hash password instead of storing plain text
                PasswordHash = dto.Password,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // map entity -> response DTO
            var response = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = string.Empty,     // never send password back
                IsActive = user.IsActive ? "true" : "false"
            };

            // 201 Created with the new user
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, response);
        }
        
        
    }
}
