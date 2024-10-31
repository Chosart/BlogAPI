using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Followers
    {
        public int Id { get; set; }

        [Required]
        public int FollowerId { get; set; }
        public User Follower { get; set; }

        [Required]
        public int FollowingId { get; set; }
        public User Following { get; set; }
    }
}
