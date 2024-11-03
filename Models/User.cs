using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        public int FollowersCount { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        [JsonIgnore]
        public ICollection<UserPostLike> UserLikes { get; set; } = new List<UserPostLike>();

        [JsonIgnore]
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [JsonIgnore]
        public ICollection<Follower> FollowerUser { get; set; } = new List<Follower>();

        [JsonIgnore]
        public ICollection<Follower> FollowingUser { get; set; } = new List<Follower>();

        [JsonIgnore]
        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public void SetPassword(string password)
        {
            Salt = Guid.NewGuid().ToString();

            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Salt));
                PasswordHash = Convert.ToBase64String(bytes);
            }
        }

        public bool ValidatePassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Salt));
                var hash = Convert.ToBase64String(bytes);
                return hash == PasswordHash;
            }
        }
    }
}
