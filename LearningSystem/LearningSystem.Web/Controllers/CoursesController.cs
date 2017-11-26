using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    public class CoursesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}