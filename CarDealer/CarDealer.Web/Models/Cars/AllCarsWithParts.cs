using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Cars
{
    public class AllCarsWithParts
    {
        public IEnumerable<CarWithPartsModel> Cars { get; set; }
    }
}
