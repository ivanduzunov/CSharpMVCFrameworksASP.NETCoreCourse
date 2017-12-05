namespace UndergroundStation.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using static DataConstants;

    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ArtistNameMinLenght)]
        [MaxLength(ArtistNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MinLength(ArtistDescriptionMinLenght)]
        [MaxLength(ArtistDescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public MusicStyle Style { get; set; }

        public List<MusicVideo> Videos { get; set; } = new List<MusicVideo>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
