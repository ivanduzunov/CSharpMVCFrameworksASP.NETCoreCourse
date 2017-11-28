using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    using Data;
    using Data.Models;

    public class TrainerController : Controller
    {
       

        public async Task<IActionResult> CourseDetails(int id)
        {
           

            return View();
        }
    }
}