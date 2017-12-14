namespace UndergroundStation.Services.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public  interface ISectionsService
    {
        Task<IEnumerable<SectionListingServiceModel>> AllAsync();
    }
}
