using BlogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BlogAPIContext _context;

        public UserController(BlogAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync();
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
    }
}
