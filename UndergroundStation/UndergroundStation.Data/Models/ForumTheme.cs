namespace UndergroundStation.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class ForumTheme
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ForumThemeTitleMinLenght)]
        [MaxLength(ForumThemeTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ForumThemeDescriptionMinLenght)]
        [MaxLength(ForumThemeDescriptionMaxLenght)]
        public string Description { get; set; }

        public List<ForumArticle> Articles { get; set; } = new List<ForumArticle>();
    }
}
