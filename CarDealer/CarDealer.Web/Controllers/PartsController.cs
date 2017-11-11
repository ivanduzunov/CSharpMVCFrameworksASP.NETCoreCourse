using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Web.Models.Parts;


namespace CarDealer.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService parts;

        public PartsController(IPartService parts)
        {
            this.parts = parts;
        }

        [Route("parts/all")]
        public IActionResult All()
        {
            var result = this.parts.All();

            return View(new PartsListModel
            {
                Parts = result
            });
        }

        [Route("parts/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("parts/create")]
        public IActionResult Create(PartsFormModel model)
        {
            return null;
        }
    }
}
