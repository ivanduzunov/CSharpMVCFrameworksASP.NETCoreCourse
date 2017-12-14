namespace UndergroundStation.Services.Forum.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Data;

    public class SectionsService : ISectionsService
    {
        private readonly UndergroundStationDbContext db;

        public SectionsService(UndergroundStationDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<SectionListingServiceModel>> AllAsync()
             => await this.db
                .ForumSections
                .ProjectTo<SectionListingServiceModel>()
                .ToListAsync();
    }
}
