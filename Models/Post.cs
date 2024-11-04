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

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserPostLike> UserLikes { get; set; } = new List<UserPostLike>();
    }
}
