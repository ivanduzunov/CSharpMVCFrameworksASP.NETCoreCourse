using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Services.Trainer.Models
{
    public class CourseDetailsTrainerServiceView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public IEnumerable<StudentGradeTrainerFormView> Students { get; set; }
    }
}
