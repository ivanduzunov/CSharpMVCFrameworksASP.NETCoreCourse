using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Trainer.Models
{
    public class StudentGradeTrainerFormView
    {
        public string Username { get; set; }

        public string UserId { get; set; }

        public int CourseId { get; set; }

        public Grade Grade { get; set; }
    }
}
