using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Articles.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Admin.Models;
    using LearningSystem.Services.Articles.Models;
    using Microsoft.EntityFrameworkCore;

    public class ArticlesService : IArticlesService
    {
        private readonly LearningSystemDbContext db;

        public ArticlesService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticlesListServiceModel>> All()
        => await this.db
            .Articles
            .ProjectTo<ArticlesListServiceModel>()
            .ToListAsync();

        public async Task CreateAsync(string title, 
            string content, 
            DateTime publishDate, 
            User author)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = publishDate,
                Author = author
            };

            this.db.Articles.Add(article);
            await this.db.SaveChangesAsync();
        }
    }
}
