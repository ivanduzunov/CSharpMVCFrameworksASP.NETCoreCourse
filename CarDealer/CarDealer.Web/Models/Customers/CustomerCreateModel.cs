using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.Models.Customers
{
    public class CustomerCreateModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [Display(Name ="Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}
