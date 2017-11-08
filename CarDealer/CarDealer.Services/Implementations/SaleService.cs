using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Implementations
{
    using Models;
    using Data;
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

    }
}
