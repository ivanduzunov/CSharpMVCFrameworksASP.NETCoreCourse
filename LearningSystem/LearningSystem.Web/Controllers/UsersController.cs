using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.User;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;

namespace LearningSystem.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserSevice users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserSevice users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var userId = user.Id;

            var profile = await this.users.ProfileAsync(userId);

            return View(profile);
        }
    }
}