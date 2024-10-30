using System.ComponentModel.DataAnnotations;
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
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
