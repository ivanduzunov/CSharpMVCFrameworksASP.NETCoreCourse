namespace UndergroundStation.Services.Implementations
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UndergroundStation.Data;
    using Models;
   
    public class NewsService : INewsService
    {
        private readonly UndergroundStationDbContext db;

        public NewsService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<NewsListingServiceModel>> AllNewsAsync()
          => await this.db
              .NewsArticles
              .ProjectTo<NewsListingServiceModel>()
              .OrderByDescending(na => na.PublishedDate)
              .ToListAsync();

    }
}
