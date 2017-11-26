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
        Task <IEnumerable<CourseListingServiceModel>> All();
    }
}
