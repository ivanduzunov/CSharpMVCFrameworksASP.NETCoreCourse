using LearningSystem.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.User.Models
{
    using AutoMapper;
    using Data.Models;
    using System.Linq;

    public class UserProfileServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string UserName { get; set; }

        public IEnumerable<UserProfileCourseSeviceModel> Courses { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, UserProfileServiceModel>()
                .ForMember(u => u.Courses, cfg => cfg.MapFrom(s => s.Courses.Select(c => c.Course)));
        }
    }
}
