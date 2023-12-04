
using System.ComponentModel.DataAnnotations;

namespace TaskoCapstone.Models
{
    public class TasksViewModel
    {

        [Required(ErrorMessage = "Name of Task Required")]
        [MaxLength(30)]
        public string? NameofTask { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StepsofTask { get; set; }

        public IFormFile? ImageofTask { get; set; }

        public bool CompletionofTask { get; set; }
        [Required]
        public int CountdownTimer { get; set; }


    }
}
