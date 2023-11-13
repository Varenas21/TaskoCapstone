using System.ComponentModel.DataAnnotations;

namespace TaskoCapstone.Models
{
    public class UserProfile
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public byte[] ProfilePicture { get; set; }

        [Required]
        string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }
}
