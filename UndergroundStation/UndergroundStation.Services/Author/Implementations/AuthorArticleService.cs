namespace UndergroundStation.Services.Author.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;

    public class AuthorArticleService : IAuthorArticleService
    {
        private readonly UndergroundStationDbContext db;

        public AuthorArticleService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title,
            string content,
            string imageUrl,
            string videoUrl)
        {
            var article = new NewsArticle
            {
                Title = title,
                Content = content,
                ImageUrl = imageUrl,
                VideoUrl = videoUrl,
                PublishedDate = DateTime.UtcNow
            };

            this.db.NewsArticles.Add(article);

            await this.db.SaveChangesAsync();
        }
    }
}
