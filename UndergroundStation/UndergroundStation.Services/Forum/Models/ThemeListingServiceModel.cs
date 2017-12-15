namespace UndergroundStation.Services.Forum.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Mapping;
    using Data.Models;

    public class ThemeListingServiceModel : IMapFrom<ForumTheme>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ForumSectionId { get; set; }

        public ForumSection ForumSection { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public DateTime PublishedDate { get; set; }

        public List<ForumArticle> Articles { get; set; } = new List<ForumArticle>();
    }
}
