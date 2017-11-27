using LearningSystem.Data.Models;
using LearningSystem.Services.Course.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Course
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> All();

        Task<CourseDetailsServiceModel> Details(int id, string userId);

        Task<bool> SignInUser(int courseId, string userId);

        Task<bool> SignOutUser(int courseId, string userId);

        Task<bool> UserIsSignedInCourse(int courseId, string userId);
    }
}
