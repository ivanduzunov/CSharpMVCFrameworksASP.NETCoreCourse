using System;
using System.Collections.Generic;
using System.Text;
using LearningSystem.Services.Admin.Models;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> All()
        => await this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToListAsync();      
    }
}
