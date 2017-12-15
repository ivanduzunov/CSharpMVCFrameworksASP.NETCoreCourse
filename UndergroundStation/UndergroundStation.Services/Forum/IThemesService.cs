namespace UndergroundStation.Services.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IThemesService
    {
        Task <bool> CreateThemeAsync(string title, string description, string creatorId, int forumSectionId, DateTime publishedDate);

        Task<ThemeDetailsServiceModel> Details(int id);
    }
}
