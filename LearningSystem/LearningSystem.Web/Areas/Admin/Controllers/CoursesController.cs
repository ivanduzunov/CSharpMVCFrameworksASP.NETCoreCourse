﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    public class CoursesController : BaseAdminController
    {
        public IActionResult Create() => View(); //todo
    }
}
