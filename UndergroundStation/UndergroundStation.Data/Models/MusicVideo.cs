namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class MusicVideo
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MusicVideoTitleMinLenght)]
        [MaxLength(MusicVideoTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public MusicStyle Style { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Like> Likes { get; set; } = new List<Like>();
    }
}
