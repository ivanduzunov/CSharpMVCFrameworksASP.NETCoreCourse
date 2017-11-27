using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.Course;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Web.Infrastructure.Extentions;

namespace LearningSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        public readonly ICourseService courses;
        public readonly UserManager<User> users;
        public readonly SignInManager<User> usersSignIn;

        public CoursesController(ICourseService courses,
            UserManager<User> users,
            SignInManager<User> usersSignIn)
        {
            this.courses = courses;
            this.users = users;
            this.usersSignIn = usersSignIn;
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var currentUser = await users.GetUserAsync(HttpContext.User);

            var course = await this.courses.Details(id, currentUser.Id);

            return View(course);
        }

        [Authorize]
   
        public async Task<IActionResult> SignIn(int id)
        {
            var currentUser = await users.GetUserAsync(HttpContext.User);

            this.courses.SignIn(currentUser.Id, id);

            TempData.AddSuccessMessage($"SUCCESS! You Sign In in the course. Good Luck!");

            return Redirect("/");
        }

        [Authorize]
     
        public async Task<IActionResult> SignOut(int id)
        {
            var currentUser = await users.GetUserAsync(HttpContext.User);

            this.courses.SignOut(currentUser.Id, id);

            TempData.AddSuccessMessage($"SUCCESS! You Sign Out from the course.");

            return Redirect("/");
        }
    }
}