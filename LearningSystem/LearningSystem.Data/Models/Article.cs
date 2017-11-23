using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Data.Models
{
    using Data;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstrants.ArticleTitleMinLength)]
        [MaxLength(DataConstrants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public User Author { get; set; }

        public string AuthorId { get; set; }
    }
}
