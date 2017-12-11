namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Common.Mapping;

    public class NewsDetailsServiceModel : IMapFrom<NewsArticle>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string VideoUrl { get; set; }

        public List<UserArticleLike> Likes { get; set; }

        public List<UserArticleUnlike> Unlikes { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
