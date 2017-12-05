namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MusicStyle Style { get; set; }

        public List<MusicVideo> Videos { get; set; } = new List<MusicVideo>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
