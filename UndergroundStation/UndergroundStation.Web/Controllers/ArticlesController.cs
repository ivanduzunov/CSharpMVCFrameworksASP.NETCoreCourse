namespace UndergroundStation.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using UndergroundStation.Services;
    using Microsoft.AspNetCore.Identity;
    using UndergroundStation.Data.Models;
    using System.Linq;

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
            var userId = userManager.GetUserId(HttpContext.User);
            var article = await news.ByIdAsync(id);

            if (article == null)
            {
                return BadRequest();
            }

            article.IsLiked = article.Likes.Where(l => l.UserId == userId) != null;

            return View(article);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLike(int articleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(HttpContext.User);

            await news.AddLikeAsync(articleId, userId);

            return RedirectToAction(nameof(Details), new { id = articleId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUnlike(int articleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(HttpContext.User);

            await news.AddUnlikeAsync(articleId, userId);

            return RedirectToAction(nameof(Details), new { id = articleId });
        }
    }
}