using System;
using System.Collections.Generic;

namespace UndergroundStation.Data.Models
{
    public class ForumSection
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<ForumArticle> Articles { get; set; } = new List<ForumArticle>();
    }
}
