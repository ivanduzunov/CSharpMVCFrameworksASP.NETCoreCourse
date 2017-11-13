using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.Models.Sales
{
    public class SaleFormModel
    {
        [Range(0, 100)]
        public double Discount { get; set; }

        [Display(Name = "Car")]
        public int CarId { get; set; }

        public IEnumerable<SelectListItem> Cars { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
