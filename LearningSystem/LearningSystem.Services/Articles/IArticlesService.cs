using LearningSystem.Data.Models;
using LearningSystem.Services.Articles.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Articles
{
    using Data.Models;

    public interface IArticlesService
    {
        Task<IEnumerable<ArticlesListServiceModel>> All();

        Task CreateAsync(string title, string content, DateTime publishDate, User author);
    }
}
