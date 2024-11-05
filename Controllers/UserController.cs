using BlogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
