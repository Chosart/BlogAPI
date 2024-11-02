using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class BlogAPIContext : DbContext
    {
        public BlogAPIContext(DbContextOptions<BlogAPIContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Post> Posts { get; set; }

    }
}
