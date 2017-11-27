using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Services.Course.Models;
using LearningSystem.Data;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LearningSystem.Services.Course.Implementations
{
    using Data.Models;
    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> All()
            => await this.db
            .Courses
            .ProjectTo<CourseListingServiceModel>()
            .ToListAsync();

        public async Task<CourseDetailsServiceModel> Details(int id, string userId)
        {
            var user = await this.db.Users.FindAsync(userId);

            var course = this.db.Courses.Where(c => c.Id == id).FirstOrDefault();
            var isSigned = user.Courses.Where(c => c.CourseId == id && c.StudentId == userId).FirstOrDefault() != null;
            var trainer = await this.db.Users.FindAsync(course.TrainerId);

            return new CourseDetailsServiceModel()
            {
                Id = id,
                Name = course.Name,
                Description = course.Description,
                Trainer = trainer,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                UserIsSigned = isSigned
            };
        }

        public void SignIn(string userId, int courseId)
        {
            var course = this.db.Courses.Where(c => c.Id == courseId).FirstOrDefault();

            var courseToAdd = new StudentCourse { StudentId = userId, CourseId = courseId };

            var user = this.db.Users.Where(c => c.Id == userId).FirstOrDefault();

            user.Courses.Add(courseToAdd);
            db.SaveChanges();
        }

        public void SignOut(string userId, int courseId)
        {
            var course = this.db.Courses.Where(c => c.Id == courseId).FirstOrDefault();
            var user = this.db.Users.Where(c => c.Id == userId).FirstOrDefault();

            var courseToRemove = course.Students.Where(s => s.StudentId == userId && s.CourseId == courseId).FirstOrDefault();

            course.Students.Remove(courseToRemove);
            user.Courses.Remove(courseToRemove);

            db.SaveChanges();
        }
    }
}
