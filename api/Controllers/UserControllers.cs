using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return Ok(userModel);
        }
        
        
    }
}