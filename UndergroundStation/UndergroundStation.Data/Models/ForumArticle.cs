namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;

    public  class ForumArticle
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public List<Comment> Answers { get; set; } = new List<Comment>();
    }
}
