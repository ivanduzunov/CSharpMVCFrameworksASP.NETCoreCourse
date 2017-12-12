namespace UndergroundStation.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using UndergroundStation.Services;
    using Microsoft.AspNetCore.Identity;
    using UndergroundStation.Data.Models;

    public class ArticlesController : Controller
    {
        private readonly INewsService news;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public ArticlesController
            (INewsService news,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.news = news;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await news.ByIdAsync(id));
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> AddLike(int articleId)
        //{
        //    return null;
        //}


    }
}