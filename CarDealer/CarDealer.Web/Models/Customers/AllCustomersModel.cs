using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Customers
{
    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection OrderDirection { get; set; }
    }
}
