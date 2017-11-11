using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CarDealer.Data.Models;
using CarDealer.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealer.Web.Models.Parts
{
    public class PartsFormModel
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Supplier")]
        public int  SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }
    }
}
