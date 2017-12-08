using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UndergroundStation.Services.Author
{
    public interface IAuthorArticleService
    {
        Task CreateAsync(string title, string content, string imageUrl, string videoUrl);    
    }
}
