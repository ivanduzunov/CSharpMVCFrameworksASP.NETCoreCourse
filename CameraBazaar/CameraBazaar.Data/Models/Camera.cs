using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Data.Models
{
    public class Camera
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        public int MinShutterSpeed  { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Range(50, 100)]
        public int MinIso { get; set; }

        [Range(200, 409600)]
        public int MaxIso { get; set; }

        [MaxLength(15)]
        public bool IsFullFrame { get; set; }

        public string VideoResolution { get; set; }

        public string LightMetering  { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
