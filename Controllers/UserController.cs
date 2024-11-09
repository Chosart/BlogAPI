using BlogAPI.Data;
using BlogAPI.Models;
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

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser (User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            if (string.IsNullOrEmpty(user.PasswordHash) || string.IsNullOrEmpty(user.Salt))
            {
                return BadRequest("PasswordHash and Salt are required");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(User), new { id = user.Id }, user);
        }

        [HttpPut("id")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            if (id != user.Id)
            {
                return BadRequest("ID in the URL does not match the user ID");
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                existingUser.SetPassword(user.PasswordHash);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
