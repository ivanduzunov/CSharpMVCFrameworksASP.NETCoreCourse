using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(OrderDirection order);

        TotalSalesByCustomerModel TotalSalesByCustomer(string id);

        void CreateCustomer(string name, DateTime birthday, bool isYoungDriver);
    }
}
