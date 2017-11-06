using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }



        public IEnumerable<CarModel> ByMake(string make)
        {
            var result = this.db.Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).ToList();

            return result
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);
        }

        public IEnumerable<CarWithPartsModel> CarsWithParts()
        {
            return this.db.Cars
                .Select(c => new CarWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                });
        }

    }
}
