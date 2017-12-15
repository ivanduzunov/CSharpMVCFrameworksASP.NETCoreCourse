namespace UndergroundStation.Services.Forum.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Models;
    using Data;


    public class ThemesService : IThemesService
    {
        private readonly UndergroundStationDbContext db;

        public ThemesService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> CreateTheme(int sectionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
