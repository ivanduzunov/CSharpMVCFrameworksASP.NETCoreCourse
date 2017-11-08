using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Sales
{
    public class AllSales
    {
        public IEnumerable<SaleListModel> Sales { get; set; }
    }
}
