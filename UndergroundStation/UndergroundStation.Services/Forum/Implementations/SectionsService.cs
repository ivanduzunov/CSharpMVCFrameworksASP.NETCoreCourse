namespace UndergroundStation.Services.Forum.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Models;
    using Data;
    using Data.Models;

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

        public async Task<SectionDetailsServiceModel> ById(int id)
        {
            var themes = await this.db.ForumThemes
                .Where(t => t.ForumSectionId == id)
                .ProjectTo<ThemeListingServiceModel>()
                .ToListAsync();

            var section = await this.db
                .ForumSections
                .Where(s => s.Id == id)
                .Select(s => new SectionDetailsServiceModel
                {
                    Tittle = s.Tittle,
                    Id = id,
                    Themes = themes
                })
                .FirstOrDefaultAsync();
           
            return  section;
        }

        public async Task<bool> Create(string title, string description)
        {
            if (title == null || description == null)
            {
                return false;
            }

            var section = new ForumSection
            {
                Tittle = title,
                Description = description
            };

            db.Add(section);

            await db.SaveChangesAsync();

            return true;
        }
    }
}
