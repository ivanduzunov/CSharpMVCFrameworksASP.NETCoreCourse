using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningSystem.Services.Admin;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Infrastructure.Extentions;
    using Models.Courses;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> users;
        private readonly IAdminCourseService courses;

        public CoursesController(UserManager<User> users,
            IAdminCourseService courses)
        {
            this.users = users;
            this.courses = courses;
        }

        public async Task<IActionResult> Create()
        {
            var result = await GetTrainers();

            return View(new AddCourseFormModel
            {
                Trainers = result,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(31)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainers();
                return View(model);
            }

            await this.courses.CreateAsync(model.Name, 
                model.Description, 
                model.StartDate, 
                model.EndDate, 
                model.TrainerId);

            TempData.AddSuccessMessage($"SUCCESS! Course {model.Name} added successully.");

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var usersTrainers = await this.users.GetUsersInRoleAsync(WebConstants.TrainerRole);

            var result = usersTrainers.Select(t => new SelectListItem
            {
                Text = t.UserName,
                Value = t.Id
            }).ToList();

            return result;

        }

    }
}
