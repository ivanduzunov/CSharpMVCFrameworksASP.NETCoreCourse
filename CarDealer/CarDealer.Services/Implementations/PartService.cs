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
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                SupplierName = p.Supplier.Name
            })
            .ToList();
        }

        public PartModel ById(string id)
          => this.db.Parts
            .Where(c => c.Id == int.Parse(id))
            .Select(c => new PartModel
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price
            }).FirstOrDefault();

        public void CreatePart(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Supplier = db.Suppliers.Where(s => s.Id == supplierId).FirstOrDefault()
            };

            db.Parts.Add(part);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(string id, decimal price, int quantity)
        {
            var existingPart = this.db.Parts.Find(int.Parse(id));

            if (existingPart == null)
            {
                return;
            }

            existingPart.Price = price;
            existingPart.Quantity = quantity;


            this.db.SaveChanges();
        }

        public bool Exists(string id)
        => this.db.Parts.Any(c => c.Id == int.Parse(id));


    }
}
