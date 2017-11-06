using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Data.Models;

namespace CarDealer.Services.Models
{
    public class CarWithPartsModel : Car
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
