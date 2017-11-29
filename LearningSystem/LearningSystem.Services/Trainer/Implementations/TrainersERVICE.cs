using LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Trainer.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Services.Trainer.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;

        public TrainerService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddGrade(Grade grade, int courseId, string userId)
        {
            if (userId == null)
            {
                return false;
            }

            var studentInCourse = await this.db.FindAsync<StudentCourse>(userId, courseId);

            studentInCourse.Grade = grade;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<CourseDetailsTrainerServiceView> CourseDetailsAsync(int id)
        {
            var course = await this.db
                .Courses
                .FindAsync(id);

            var students = await this.db
                .Users.Where(u => u.Courses.Any(c => c.CourseId == id))
                .Select(s => new StudentGradeTrainerFormView
                {
                    UserId = s.Id,
                    CourseId = id,
                    Username = s.UserName,
                })
                .ToListAsync();

            var result = new CourseDetailsTrainerServiceView
            {
                Id = id,
                Name = course.Name,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Students = students
            };

            return result;

        }
    }
}
