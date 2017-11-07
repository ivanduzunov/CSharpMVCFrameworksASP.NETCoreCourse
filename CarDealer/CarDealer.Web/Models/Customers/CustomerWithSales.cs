using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Customers
{
    public class CustomerWithSales
    {
        public  TotalSalesByCustomerModel Sales { get; set; }
    }
}
