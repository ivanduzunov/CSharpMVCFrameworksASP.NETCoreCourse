namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Services.Forum;
    using Models.Themes;

    using static WebConstants;

    [Area(ForumArea)]
    public class ThemesController : Controller
    {
        private readonly IThemesService themes;
        private readonly IArticleService articles;

        public ThemesController
            (IThemesService themes,
            IArticleService articles)
        {
            this.themes = themes;
            this.articles = articles;
        }

        [Authorize]
        public async Task<IActionResult> Details(string themeId, string page)
        {
            int id = int.Parse(themeId);
            int pageNum = int.Parse(page);

            var theme = new ThemeDetailsViewModel
            {
                ThemeDetails = await this.themes.ById(id),
                Articles = await this.articles.ByThemeId(id, pageNum),
                TotalArticles = await this.articles.TotalByThemeId(id),
                CurrentPage = pageNum
            };

            return View(theme);
        }





    }
}