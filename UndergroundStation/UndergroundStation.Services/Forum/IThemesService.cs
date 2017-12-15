namespace UndergroundStation.Services.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IThemesService
    {
        Task<bool> CreateTheme(int sectionId);
    }
}
