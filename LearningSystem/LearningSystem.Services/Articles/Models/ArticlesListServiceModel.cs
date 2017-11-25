using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using LearningSystem.Data;

namespace LearningSystem.Services.Articles.Models
{
    using Common.Mapping;
    using Data.Models;

    public class ArticlesListServiceModel : IMapFrom<Article>
    {
        [Required]
        [MinLength(DataConstrants.ArticleTitleMinLength)]
        [MaxLength(DataConstrants.ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId{ get; set; }

        public User Author { get; set; }
    }
}
