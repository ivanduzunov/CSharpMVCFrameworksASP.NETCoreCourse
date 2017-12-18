namespace UndergroundStation.Services.Forum.Models
{
    using System.Collections.Generic;
    using UndergroundStation.Common.Mapping;
    using Data.Models;
    using System;
    using AutoMapper;

    public class ArticleAnswerListingServiceModel : IMapFrom<ForumArticle>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public string authorUserName { get; set; }

        public string MotherArticleTitle { get; set; }

        public List<Like> Likes { get; set; } = new List<Like>();


    }
}
