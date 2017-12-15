namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Services.Forum;

    using static WebConstants;

    [Area(ForumArea)]
    public class ThemesController : Controller
    {
        private readonly IThemesService themes;

        public ThemesController(IThemesService themes)
        {
            this.themes = themes;
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var result = await themes.Details(id);

            return View(result);
        }





    }
}