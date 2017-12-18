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

        public IActionResult Details(int id)
        {
            var userId =  userManager.GetUserId(HttpContext.User);

            var article = news.ByIdAsync(id);

            if (article == null)
            {
                return BadRequest();
            }

            article.IsLiked = article.Likes.Where(l => l.UserId == userId).Count() > 0;

            return View(article);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUnlike(int id)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var success = await news.AddUnlikeAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLike(int id)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var success = await news.AddLikeAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCommentByArticle(int id, string comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = userManager.GetUserId(HttpContext.User);

            var success = await news.AddCommentByArticleAsync(comment, id, userId);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCommentByComment(int id, string answer, int articleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(HttpContext.User);

            var success = await news.AddCommentByCommentAsync(answer, id, userId);

            if (!success)
            {
                return BadRequest();
            }

            id = articleId;

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}