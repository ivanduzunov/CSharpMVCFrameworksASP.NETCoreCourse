using LearningSystem.Services.User.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.User
{
    public interface IUserSevice
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);
    }
}
