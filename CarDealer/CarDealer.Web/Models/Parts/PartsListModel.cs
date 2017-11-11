using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Services.Models;

namespace CarDealer.Web.Models.Parts
{
    public class PartsListModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
