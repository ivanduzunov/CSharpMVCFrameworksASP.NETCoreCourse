using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Implementations
{
    using Models;
    using Data;
    using Data.Models;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleListModel> All()
       => this.db.Sales.Select(s => new SaleListModel
       {
           Id = s.Id,
           CustomerName = s.Customer.Name,
           Price = s.Car.Parts.Sum(p => p.Part.Price),
           IsYoungDriver = s.Customer.IsYoungDriver,
           Discount = s.Discount
       }).ToList();

       
        public SaleDetailsModel SaleDetails(string id)
                => db.Sales.Where(s => s.Id == int.Parse(id))
                .Select(s => new SaleDetailsModel
                {
                    CustomerName = s.Customer.Name,
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                })
            .FirstOrDefault();

        public void Create(int carId, int customerId, double discount)
        {
            
           var sale = new Sale
            {
                Car = this.db.Cars.Where(c => c.Id == carId).FirstOrDefault(),
                Customer = this.db.Customers.Where(c => c.Id == customerId).FirstOrDefault(),
                Discount = discount
            };


            this.db.Sales.Add(sale);

            this.db.SaveChanges();
        }


    }
}
