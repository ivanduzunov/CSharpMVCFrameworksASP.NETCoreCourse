namespace UndergroundStation.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface INewsService
    {
        Task<IEnumerable<NewsListingServiceModel>> AllNewsAsync();
    }
}
