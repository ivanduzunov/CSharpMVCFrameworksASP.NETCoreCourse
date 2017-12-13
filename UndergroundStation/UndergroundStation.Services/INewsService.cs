namespace UndergroundStation.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface INewsService
    {
        Task<IEnumerable<NewsListingServiceModel>> AllNewsAsync();

        Task<NewsDetailsServiceModel> ByIdAsync(int id);

        Task<bool> AddUnlikeAsync(int articleId, string userId);

        Task<bool> AddLikeAsync(int articleId, string userId);
    }
}
