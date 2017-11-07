using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class TotalSalesByCustomerModel
    {
        public string Name { get; set; }

        public int BoughtCarsCount { get; set; }

        public decimal TotalSpendMoney { get; set; }
    }
}
