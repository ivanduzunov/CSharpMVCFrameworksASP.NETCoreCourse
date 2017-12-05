namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class NewsArticle
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string  VideoUrl { get; set; }

        public List<UserLike> Likes { get; set; }

        public List<UserUnlike> Unlikes { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
