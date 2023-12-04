using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace TaskoCapstone.Models
{
    public class TaskManager
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of Task Required")]
        [MaxLength(30)]
        public string? NameofTask { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string StepsofTask { get; set; }

        public string? ImageofTask { get; set; } = "https://www.firstbenefits.org/wp-content/uploads/2017/10/placeholder.png";

        public bool CompletionofTask { get; set; }
        [Required]
        public int CountdownTimer { get; set; }

        public TaskManager() { }

        public TaskManager(string nameofTask, string description, string stepsofTask, string imageofTask, bool completionofTask, int timer)
        {
            NameofTask = nameofTask;
            Description = description;
            StepsofTask = nameofTask;
            ImageofTask = imageofTask;
            StepsofTask = stepsofTask;
            CompletionofTask = completionofTask;
            CountdownTimer = timer;
        }
    }
}
