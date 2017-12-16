namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Common.Mapping;
    using Data.Models.Enums;

    public class NewsDetailsServiceModel : IMapFrom<NewsArticle>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool IsLiked { get; set; }

        public ArticleType ArticleType { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
