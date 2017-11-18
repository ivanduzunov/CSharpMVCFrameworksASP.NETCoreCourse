using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraBazaar.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Web.Models.Camera
{
    public class CameraCreateViewModel
    {
        [Required]
        [Display(Name = "Make:")]
        public MakeType Make { get; set; }

        [Required]
        [Display(Name = "Model:")]
        [RegularExpression("[A-Za-z0-9- ]+", ErrorMessage = "The model can contains only uppercase letters, digits and '-' sign.")]
        public string CameraModel { get; set; }

        [Required]
        [Display(Name = "Price:")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Quantity:")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 30)]
        [Display(Name = "Minimum Shutter Speed:")]
        public int MinShutterSpeed { get; set; }

        [Required]
        [Range(2000, 8000)]
        [Display(Name = "Maximum Shutter Speed:")]
        public int MaxShutterSpeed { get; set; }

        [Required]
        [Display(Name = "Min ISO:")]
        public MinISOType MinISO { get; set; }

        [Required]
        [Range(200, 409600)]
        [Display(Name = "Max ISO:")]
        public int MaxISO { get; set; }

        [Required]
        [Display(Name = "Has Full Frame:")]
        public bool IsFullFrame { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Display(Name = "Video Resolution:")]
        public string VideoResolution { get; set; }

        [Required]
        [Display(Name = "Light Metering:")]
        public IEnumerable<LightMeteringType> LightMetering { get; set; }

        [Required]
        [StringLength(6000, MinimumLength = 10)]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"http:\/\/.*|https:\/\/.*", ErrorMessage = "Invalid url format.")]
        [StringLength(2000, MinimumLength = 10)]
        [Display(Name = "Image URL:")]
        public string ImageUrl { get; set; }
    }
}
