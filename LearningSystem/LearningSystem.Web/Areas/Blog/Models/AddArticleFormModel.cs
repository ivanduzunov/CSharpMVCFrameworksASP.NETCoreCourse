using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LearningSystem.Data;
using LearningSystem.Data.Models;

namespace LearningSystem.Web.Areas.Blog.Models
{
    public class AddArticleFormModel
    {
        [Required]
        [MinLength(DataConstrants.ArticleTitleMinLength)]
        [MaxLength(DataConstrants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public User Author { get; set; }

        public string AuthorId { get; set; }
    }
}
