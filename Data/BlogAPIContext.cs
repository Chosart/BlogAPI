using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class BlogAPIContext : DbContext
    {
        public BlogAPIContext(DbContextOptions<BlogAPIContext> options) : base(options)
        {

        }
    }
}
