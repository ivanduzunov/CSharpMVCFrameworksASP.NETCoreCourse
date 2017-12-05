namespace UndergroundStation.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using static DataConstants;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CommentTitleMinLenght)]
        [MaxLength(CommentTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(CommentContentMinLenght)]
        [MaxLength(CommentContentMaxLenght)]
        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public int? ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int? MusicVideoId { get; set; }

        public MusicVideo MusicVideo { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int? AnswerCommentId { get; set; }

        public Comment AnswerComment { get; set; }

        public List<Comment> Answers { get; set; } = new List<Comment>();
    }
}
