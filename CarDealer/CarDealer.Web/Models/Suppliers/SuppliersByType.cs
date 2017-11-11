using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Suppliers
{
    public class SuppliersByType
    {
        public IEnumerable<SupplierListingModel> Suppliers { get; set; }

        public string Type { get; set; }
    }
}
