namespace CameraBazaar.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class CamerasController : Controller
    {
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
    }
}