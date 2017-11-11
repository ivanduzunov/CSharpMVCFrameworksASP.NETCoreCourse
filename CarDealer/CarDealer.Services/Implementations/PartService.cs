using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Data;
using CarDealer.Data.Models;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartModel> All()
        {
            var parts = this.db.Parts;

            return parts.Select(p => new PartModel
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierName = p.Supplier.Name
            })
            .ToList();
        }
    }
}
