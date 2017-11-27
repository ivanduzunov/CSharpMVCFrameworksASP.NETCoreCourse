using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Course.Models
{
    public class CourseDetailsServiceModel : CourseListingServiceModel
    {
        public bool UserIsSigned { get; set; }
    }
}
