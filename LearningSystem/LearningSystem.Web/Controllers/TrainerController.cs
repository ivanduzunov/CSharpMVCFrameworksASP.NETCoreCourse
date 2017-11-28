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
        public async Task<IActionResult> AddGrade(StudentGradeTrainerServiceView model)
        {
            //receive null value of the model
            //ee how Kenov did it with the asigning users to role and fix it
            return null;
        }
    }
}