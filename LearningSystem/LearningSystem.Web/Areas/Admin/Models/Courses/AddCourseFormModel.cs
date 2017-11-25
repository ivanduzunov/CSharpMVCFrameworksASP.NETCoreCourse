using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LearningSystem.Data;

namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
    public class AddCourseFormModel : IValidatableObject
    {
        [Required]
        [MinLength(DataConstrants.CourseNameMinLength)]
        [MaxLength(DataConstrants.CourseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DataConstrants.CourseDescriptionMinLength)]
        [MaxLength(DataConstrants.CourseDescriptionMaxLength)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        public string TrainerId { get; set; }

        public IEnumerable<SelectListItem> Trainers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start date connot be in the past.");
            }

            if (this.EndDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("End date connot be in the past.");
            }

            if (this.EndDate <= this.StartDate)
            {
                yield return new ValidationResult("End date connot be before Start date.");
            }
        }
    }
}
