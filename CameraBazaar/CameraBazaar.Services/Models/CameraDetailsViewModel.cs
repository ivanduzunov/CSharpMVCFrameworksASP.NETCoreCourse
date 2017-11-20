using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CameraBazaar.Data.Enums;

namespace CameraBazaar.Services.Models
{
    public class CameraDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public MakeType Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string SellersUsername { get; set; }

        public bool IsInStock { get; set; }

        public string ImageUrl { get; set; }

        public int MinShutterSpeed { get; set; }

        public int MaxShutterSpeed { get; set; }

        public MinISOType MinISO { get; set; }

        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        public string VideoResolution { get; set; }

        public LightMeteringType LightMeterings { get; set; }

        public string Description { get; set; }
    }
}
