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

            bool isSigned = await UserIsSignedInCourse(id, userId);

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

        public async Task<bool> SignInUser(int courseId, string userId)
        {
            var courseInfo = await this.db.Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    c.StartDate,
                    UserIdSignedIn = c.Students.Any(s => s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

            if (courseInfo.StartDate < DateTime.UtcNow
                || courseInfo.UserIdSignedIn)
            {
                return false;
            }

            var studentCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = userId
            };
            this.db.Add(studentCourse);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutUser(int courseId, string userId)
        {
            var courseInfo = await this.db.Courses
                 .Where(c => c.Id == courseId)
                 .Select(c => new
                 {
                     c.StartDate,
                     UserIdSignedIn = c.Students.Any(s => s.StudentId == userId)
                 })
                 .FirstOrDefaultAsync();

            if (courseInfo == null ||
                courseInfo.StartDate < DateTime.UtcNow)
            {
                return false;
            }
            //IDIOT WAY TO DO IT !!!
            var studentInCourse = await this.db
                 .FindAsync(typeof(StudentCourse),
                 userId,
                 courseId);

            this.db.Remove(studentInCourse);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UserIsSignedInCourse(int courseId, string userId)
        => await this.db
            .Courses
            .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == userId));
    }
}
