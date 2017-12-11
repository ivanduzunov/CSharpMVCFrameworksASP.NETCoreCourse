namespace UndergroundStation.Services.Models
{
    using System;
    using System.Collections.Generic;
    using UndergroundStation.Common.Mapping;
    using Data.Models;

    public class NewsListingServiceModel: IMapFrom<NewsArticle>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedDate { get; set; }
    }
}
