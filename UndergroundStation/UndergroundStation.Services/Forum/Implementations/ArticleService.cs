namespace UndergroundStation.Services.Forum.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Data;
    using Data.Models;


    public class ArticleService : IArticleService
    {
        private readonly UndergroundStationDbContext db;

        public ArticleService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create
            (string title,
            string content,
            string authorId,
            int forumThemeId,
            DateTime publishedDate,
            int motherArticleId)
        {
            if (content == null || title == null)
            {
                return false;
            }

            if (motherArticleId ==0)
            {
                var article = new ForumArticle
                {
                    Title = title,
                    Content = content,
                    AuthorId = authorId,
                    ForumThemeId = forumThemeId,
                    PublishedDate = publishedDate
                };

                this.db.Add(article);

                await this.db.SaveChangesAsync();
            }    

            return true;
        }

        public async Task<bool> CreateAnswerAsync
            (string title,
            string content, 
            string authorId, 
            DateTime publishedDate, 
            int motherArticleId)
        {
            if (content == null || motherArticleId == 0)
            {
                return false;
            }

            var article = new ForumArticle
            {
                Title = "Re: " +  title,
                Content = content,
                AuthorId = authorId,
                MotherArticleId = motherArticleId,
                PublishedDate = publishedDate
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
