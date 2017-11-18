namespace CameraBazaar.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Data.Models;
    using Services;
    using Models.Camera;

    public class CamerasController : Controller
    {
        private readonly ICameraService cameras;
        private readonly UserManager<User> userManager;

        public CamerasController(ICameraService cameras, UserManager<User> userManager)
        {
            this.cameras = cameras;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CameraCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            cameras.Create
                (
                model.Make,
                model.CameraModel,
                model.Price,
                model.Quantity,
                model.Description,
                model.IsFullFrame,
                model.LightMetering,
                model.MinISO,
                model.MaxISO,
                model.MinShutterSpeed,
                model.MaxShutterSpeed,
                model.ImageUrl,
                model.VideoResolution,
                this.userManager.GetUserId(User)
                );

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}