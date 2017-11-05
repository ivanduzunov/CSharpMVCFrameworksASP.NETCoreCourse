using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class CutomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CutomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDay).ThenBy(c => c.Name);
                    break;

                case OrderDirection.Descending:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDay).ThenBy(c => c.Name);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid order direction - {order}");
            }

            return customersQuery.Select(c => new CustomerModel
            {
                Name = c.Name,
                BirthDay = c.BirthDay,
                IsYoungDriver = c.IsYoungDriver
            }).ToList();
        }
    }
}
