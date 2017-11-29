using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    using Data;
    using Data.Models;
    using LearningSystem.Services.Trainer;
    using LearningSystem.Services.Trainer.Models;
    using LearningSystem.Web.Infrastructure.Extentions;
    using Microsoft.AspNetCore.Authorization;

    public class TrainerController : Controller
    {
        private readonly ITrainerService trainers;

        public TrainerController(ITrainerService trainers)
        {
            this.trainers = trainers;
        }

        [Authorize]
        public async Task<IActionResult> CourseDetails(int id)
        {
            var result = await this.trainers.CourseDetailsAsync(id);

            return View(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddGrade(Grade grade, int courseId, string userId)
        {
            await this.trainers.AddGrade(grade, courseId, userId);

            TempData.AddSuccessMessage($"SUCCESS! Grade added!");

            return Redirect($"/trainer/CourseDetails/{courseId}");
        }
    }
}