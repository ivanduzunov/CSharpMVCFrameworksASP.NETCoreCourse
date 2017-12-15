namespace UndergroundStation.Services.Forum.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Models;

    public class ArticleListingServiceModel : IMapFrom<ForumArticle>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int ForumThemeId { get; set; }

        public ForumTheme ForumTheme { get; set; }

        public List<ForumArticle> Answers { get; set; } = new List<ForumArticle>();

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
