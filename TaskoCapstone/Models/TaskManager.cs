﻿using System.ComponentModel.DataAnnotations;

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

        public string ImageofTask { get; set; }



        public TaskManager(string nameofTask, string description, string stepsofTask, string imageofTask)
        {
            NameofTask = nameofTask;
            Description = description;
            StepsofTask = nameofTask;
            ImageofTask = imageofTask;
            StepsofTask = stepsofTask;

        }
    }
}
