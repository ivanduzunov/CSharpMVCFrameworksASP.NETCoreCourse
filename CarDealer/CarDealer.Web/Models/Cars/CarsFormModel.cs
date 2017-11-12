using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealer.Web.Models.Cars
{
    public class CarsFormModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        [Display(Name = "Parts")]
        public List<int> PartsIds { get; set; }

        public IEnumerable<SelectListItem> Parts { get; set; }
    }
}
