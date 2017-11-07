using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class SaleModel
    {
        public CarModel Car { get; set; }

        public CustomerModel Customer { get; set; }

        public decimal PriceWithoutDiscount { get; set; }

        public decimal PriceWithDiscount { get; set; }

        public double DiscountPercent { get; set; }
    }
}
