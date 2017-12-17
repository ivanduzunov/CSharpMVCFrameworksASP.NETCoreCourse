namespace UndergroundStation.Services.Implementations
{
    using System;
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

        public NewsDetailsServiceModel ByIdAsync(int id)
        {
            var result = this.db
                  .NewsArticles
                  .Where(a => a.Id == id)
                  .ProjectTo<NewsDetailsServiceModel>()
                  .FirstOrDefault();

            var comments =  this.db.Comments
                            .Where(c => c.NewsArticleId == id)
                            .Select(na => new CommentsListingServiceModel
                            {
                                Id = na.Id,
                                Content = na.Content,
                                PublishedDate = na.PublishedDate,
                                AuthorUserName = na.Author.UserName,
                                Answers =  this.db.Comments
                                            .Where(c => c.MotherCommentId == na.Id)
                                            .Select(an => new CommentsListingServiceModel
                                            {
                                                Id = an.Id,
                                                Content = an.Content,
                                                PublishedDate = an.PublishedDate,
                                                AuthorUserName = an.Author.UserName
                                            }).ToList()
                            }).ToList();

            result.Comments = comments;
    
            return result;
        }

        public async Task<bool> AddLikeAsync(int articleId, string userId)
        {
            if (articleId == 0 || userId == null)
            {
                return false;
            }

            var like = new Like
            {
                UserId = userId,
                NewsArticleId = articleId,
                IsLiked = true
            };

            await this.db.AddAsync(like);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddUnlikeAsync(int articleId, string userId)
        {
            if (articleId == 0 || userId == null)
            {
                return false;
            }

            var like = new Like
            {
                UserId = userId,
                NewsArticleId = articleId,
                IsLiked = false
            };

            await this.db.AddAsync(like);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentByArticleAsync(string comment, int id, string userId)
        {
            if (comment == null || id == 0 || userId == null)
            {
                return false;
            }

            var result = new Comment
            {
                Title = "comment",
                Content = comment,
                AuthorId = userId,
                NewsArticleId = id,
                PublishedDate = DateTime.UtcNow
            };

            this.db.Add(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddCommentByCommentAsync(string answer, int id, string userId)
        {
            if (answer == null || id == 0 || userId == null)
            {
                return false;
            }

            var result = new Comment
            {
                Title = "comment",
                Content = answer,
                AuthorId = userId,
                MotherCommentId = id,
                PublishedDate = DateTime.UtcNow
            };

            this.db.Add(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        

       
    }
}
