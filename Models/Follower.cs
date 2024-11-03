using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Follower
    {
        public int Id { get; set; }

        [Required]
        public int FollowerId { get; set; }
        public User FollowerUser { get; set; }

        [Required]
        public int FollowingId { get; set; }
        public User FollowingUser { get; set; }
    }
}
