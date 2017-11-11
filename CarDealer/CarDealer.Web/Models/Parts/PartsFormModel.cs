using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.Models.Parts
{
    public class PartsFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
