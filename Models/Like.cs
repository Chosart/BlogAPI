using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Like
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
