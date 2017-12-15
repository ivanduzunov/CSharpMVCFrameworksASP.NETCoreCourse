namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Extentions;
    using Data.Models;
    using Models.Articles;
    using Services.Forum;

    using static WebConstants;

    [Area(ForumArea)]
    public class ArticlesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IArticleService articles;

        public ArticlesController
            (UserManager<User> userManager,
            IArticleService articles)
        {
            this.userManager = userManager;
            this.articles = articles;
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ArticlesCreateFormModel
            {
                AuthorId = user.Id,
                ForumThemeId = id,
                PublishedDate = DateTime.UtcNow
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create
            (ArticlesCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var success = await this.articles.Create
                (model.Title,
                model.Content,
                model.AuthorId,
                model.ForumThemeId,
                model.PublishedDate,
                model.MotherArticleId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Theme {model.Title} successfully published.");

            return this.Redirect($"/forum/themes/details/{model.ForumThemeId}");
        }
    }
}