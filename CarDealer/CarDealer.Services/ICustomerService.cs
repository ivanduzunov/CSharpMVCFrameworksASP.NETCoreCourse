﻿using System;
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

        void Edit(string id, string name, DateTime birthday, bool isYoungDriver);

        CustomerModel ById(string id);

        bool Exists(string id);
    }
}
