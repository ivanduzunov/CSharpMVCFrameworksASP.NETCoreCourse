using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Cars;

namespace CarDealer.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService cars;

        public CarsController(ICarService car)
        {
            this.cars = car;
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
    }
}
