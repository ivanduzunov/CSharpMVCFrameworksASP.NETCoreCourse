namespace UndergroundStation.Services.Implementations
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
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

        public async Task<NewsDetailsServiceModel> ByIdAsync(int id)
                => await this.db
                .NewsArticles
                .Where(a => a.Id == id)
                .ProjectTo<NewsDetailsServiceModel>()
                .FirstOrDefaultAsync();
        
    }
}
