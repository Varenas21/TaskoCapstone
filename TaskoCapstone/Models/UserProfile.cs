using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskoCapstone.Models
{
    public class UserProfile : IdentityUser<Guid>
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [PersonalData]
        public byte[] ProfilePicture { get; set; }

        [Required]
        [PersonalData]
        string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }
}
