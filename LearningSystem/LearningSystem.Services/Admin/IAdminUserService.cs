﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin
{
    using Models;
    using Data.Models;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> All();
    }
}
