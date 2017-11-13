using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService car, IPartService parts)
        {
            this.cars = car;
            this.parts = parts;
        }

        [Route("cars/{make}")]
        public IActionResult CarsByMake(string make)
        {
            var result = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Cars = result,
                Make = make
            });
        }

        [Route("cars/parts")]
        public IActionResult CarsWithParts()
        {
            var result = cars.CarsWithParts();

            return View(new AllCarsWithParts
            {
                Cars = result
            });
        }

        [Authorize]
        [Route("cars/create")]
        public IActionResult Create()
        {
            return View(new CarsFormModel
            {
                Parts = this.parts.All()
               .Select(s => new SelectListItem
               {
                   Text = s.Name,
                   Value = s.Id.ToString()
               })
            });
        }

        [Authorize]
        [HttpPost]
        [Route("cars/create")]
        public IActionResult Create(CarsFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }

            this.cars.Create(carModel.Make, carModel.Model,
                carModel.TravelledDistance, carModel.PartsIds);

            return this.Redirect("/cars/parts");
        }
    }
}
