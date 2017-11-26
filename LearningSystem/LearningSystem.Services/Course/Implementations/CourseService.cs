using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Services.Course.Models;
using LearningSystem.Data;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Services.Course.Implementations
{
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
    }
}
