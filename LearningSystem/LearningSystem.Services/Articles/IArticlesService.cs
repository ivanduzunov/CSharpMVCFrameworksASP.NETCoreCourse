using LearningSystem.Services.Articles.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Articles
{
    public interface IArticlesService
    {
        Task<IEnumerable<ArticlesListServiceModel>> All();

        Task CreateAsync(string title, string content, DateTime publishDate, string authorId);
    }
}
