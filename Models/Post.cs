using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
