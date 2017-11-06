using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Services;
using CarDealer.Data;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> AllSuppliers(string type)
        {
            var suppliersQuery = db.Suppliers.AsQueryable();

            switch (type.ToLower())
            {
                case "local":
                    suppliersQuery = suppliersQuery.Where(s => s.IsInporter == false);
                    break;

                case "importers":
                    suppliersQuery = suppliersQuery.Where(s => s.IsInporter == true);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid supplier type - {type}");
            }

            var result = suppliersQuery
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count
                }).ToList();

            return result;
        }
    }
}
