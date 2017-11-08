using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarDealer.Services.Models
{
    public class TotalSalesByCustomerModel
    {
        public string Name { get; set; }


        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public decimal TotalSpendMoney
                    => this.BoughtCars
                    .Sum(c => c.Price * (1 - (decimal)c.Discount))
                    * (this.IsYoungDriver ? 0.95m : 1);
    }
}
