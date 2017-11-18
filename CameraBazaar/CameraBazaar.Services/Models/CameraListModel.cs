using System;
using System.Collections.Generic;
using System.Text;

namespace CameraBazaar.Services.Models
{
    public class CameraListModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsInStock { get; set; }
    }
}
