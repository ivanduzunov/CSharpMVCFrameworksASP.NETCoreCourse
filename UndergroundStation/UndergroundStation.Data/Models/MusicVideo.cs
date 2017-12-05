namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class MusicVideo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public MusicStyle Style { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
