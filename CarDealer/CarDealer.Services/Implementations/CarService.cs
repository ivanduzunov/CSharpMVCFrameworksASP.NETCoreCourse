using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;
using CarDealer.Data.Models;

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

        public void Create(string make, string modelCar,
            long travelledDistance, List<int> partsId)
        {           
            var car = new Car
            {
                Make = make,
                Model = modelCar,
                TravelledDistance = travelledDistance
            };

            //Add parts to the added car

            foreach (var part in this.db.Parts)
            {
                if (partsId.Contains(part.Id))
                {
                    car.Parts.Add(new PartCar
                    {
                        Part = part,
                        Car = car
                    });
                }
            }

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }
    }
}
