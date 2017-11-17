using System;
using System.Collections.Generic;
using System.Text;

namespace CameraBazaar.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public MakeType Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Required]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Required]
        public MinISOType MinISO { get; set; }

        [Required]
        [Range(200, 409600)]
        public int MaxISO { get; set; }

        [Required]
        public bool IsFullFrame { get; set; }

        [Required]
        [MaxLength(15)]
        public string VideoResolution { get; set; }

        [Required]
        public LightMeteringType LightMetering { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
