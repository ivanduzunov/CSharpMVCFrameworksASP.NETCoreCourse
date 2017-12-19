namespace UndergroundStation.Services.Forum.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Models;
    using Data;
    using Data.Models;
    using System;

    public class ThemesService : IThemesService
    {
        private readonly UndergroundStationDbContext db;

        public ThemesService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateThemeAsync
           (string title,
            string description,
            string creatorId, 
            int forumSectionId,
            DateTime publishedDate)
        {
            if (title == null 
                || description == null 
                || creatorId == null
                || forumSectionId == 0
                || publishedDate == null)
            {
                return false;
            }

            var theme = new ForumTheme
            {
                Title = title,
                Description = description,
                Creator = this.db.Users.Where(u => u.Id == creatorId).FirstOrDefault(),
                ForumSection = this.db.ForumSections.Where(fs => fs.Id == forumSectionId).FirstOrDefault(),
                PublishedDate = publishedDate
            };

            this.db.Add(theme);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<ThemeDetailsServiceModel> ById(int id)
           => await this.db.ForumThemes
                .Where(ft => ft.Id == id)
                .ProjectTo<ThemeDetailsServiceModel>()
                .FirstOrDefaultAsync();
                
        
    }
}
