using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    public class SectionsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}