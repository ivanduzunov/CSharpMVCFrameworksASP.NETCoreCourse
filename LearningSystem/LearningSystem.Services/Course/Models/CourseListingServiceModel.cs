using LearningSystem.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Course.Models
{
    using Data.Models;

    public class CourseListingServiceModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User Trainer { get; set; }

        public string TrainerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
