namespace UndergroundStation.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using UndergroundStation.Services;

    public class ArticlesController : Controller
    {
        private readonly INewsService news;

        public ArticlesController(INewsService news)
        {
            this.news = news;
        }

        public async Task<IActionResult> Details(int id)
        => View(await news.ByIdAsync(id));
    }
}