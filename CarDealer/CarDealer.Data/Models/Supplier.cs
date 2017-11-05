using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsInporter { get; set; }

        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
