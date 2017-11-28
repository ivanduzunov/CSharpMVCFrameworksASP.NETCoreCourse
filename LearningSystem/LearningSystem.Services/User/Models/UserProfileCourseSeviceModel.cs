using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.User.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Linq;

    public class UserProfileCourseSeviceModel : IMapFrom<Course>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Grade Grade { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            string userId = null;

            mapper
                .CreateMap<Course, UserProfileCourseSeviceModel>()
                .ForMember(p => p.Grade, cfg => cfg.MapFrom(c => c.Students.Where(s => s.StudentId == userId).Select(s => s.Grade).FirstOrDefault()));
        }
    }
}
