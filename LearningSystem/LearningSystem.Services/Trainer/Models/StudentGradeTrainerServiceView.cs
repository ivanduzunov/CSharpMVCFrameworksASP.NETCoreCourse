using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Trainer.Models
{
    public class StudentGradeTrainerServiceView
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public Grade Grade { get; set; }
    }
}
