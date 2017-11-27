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

        void SignIn(string userId, int courseId);

        void SignOut(string userId, int courseId);
    }
}
