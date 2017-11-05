using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
