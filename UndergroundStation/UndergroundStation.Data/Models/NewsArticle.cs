namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class NewsArticle
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NewsArticleTitleMinLenght)]
        [MaxLength(NewsArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(NewsArticleContentMinLenght)]
        [MaxLength(NewsArticleContentMaxLenght)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public DateTime PublishedDate { get; set; }

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
