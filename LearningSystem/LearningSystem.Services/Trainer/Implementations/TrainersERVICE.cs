using LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Trainer.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningSystem.Data.Models;

namespace LearningSystem.Services.Trainer.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<CourseDetailsTrainerServiceView> CourseDetailsAsync(int id)
        {
            IEnumerable<SelectListItem> grades = null;

            var gradesEnum =  Enum.GetValues(typeof(Grade));
            foreach (var item in grades)
            {
                
            }
            .ForEach(t => new SelectListItem
            {
                Text = t.UserName,
                Value = t.Id
            }).ToList();

            var students = await this.db
                .Users.Where(u => u.Courses.Any(c => c.CourseId == id))
                .Select(s => new StudentGradeTrainerServiceView
                {
                    UserName = s.UserName,
                    Grades = new SelectListItem
                    {
                        Text = Enum.GetNames(Grade)
                    }
                }).ToListAsync();

        }
    }
}
