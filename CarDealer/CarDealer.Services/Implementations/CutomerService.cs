using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;
using CarDealer.Data;
using CarDealer.Data.Models;
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
                Id = c.Id,
                Name = c.Name,
                BirthDay = c.BirthDay,
                IsYoungDriver = c.IsYoungDriver
            }).ToList();
        }

        public TotalSalesByCustomerModel TotalSalesByCustomer(string id)
        {

            var customer = this.db.Customers
                .Where(c => c.Id == int.Parse(id))
                .Select(c => new TotalSalesByCustomerModel
                {
                    Name = c.Name,

                    IsYoungDriver = c.IsYoungDriver,
                    BoughtCars = c.Sales.Select(s => new SaleModel
                    {
                        Price = s.Car.Parts.Sum(p => p.Part.Price),
                        Discount = s.Discount
                    })
                })
                .FirstOrDefault();


            return customer;
        }

        public void CreateCustomer(string name, DateTime birthday, bool isYoungDriver)
        {
            var cust = new Customer
            {
                Name = name,
                BirthDay = birthday,
                IsYoungDriver = isYoungDriver
            };

            this.db.Customers.Add(cust);
            this.db.SaveChanges();
        }

        public void Edit(string id, string name, DateTime birthday, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(int.Parse(id));

            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDay = birthday;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public CustomerModel ById(string id)
            => this.db.Customers
            .Where(c => c.Id == int.Parse(id))
            .Select(c => new CustomerModel
            {
                Id = c.Id,
                Name = c.Name,
                BirthDay = c.BirthDay,
                IsYoungDriver = c.IsYoungDriver
            }).FirstOrDefault();

        public bool Exists(string id)
        => this.db.Customers.Any(c => c.Id == int.Parse(id));
    }
}
