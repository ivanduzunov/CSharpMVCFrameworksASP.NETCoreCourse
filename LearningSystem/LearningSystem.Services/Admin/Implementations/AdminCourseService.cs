﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LearningSystem.Services.Admin.Implementations
{
    using Data;
    using LearningSystem.Data.Models;
    using System.Threading.Tasks;

    public class AdminCourseService : IAdminCourseService
    {
        private readonly LearningSystemDbContext db;

        public AdminCourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string trainerId)
        {
            var course = new Course
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                TrainerId = trainerId
            };

            this.db.Courses.Add(course);
            await this.db.SaveChangesAsync();
        }
    }
}
