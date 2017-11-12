using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class PartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
    }
}
