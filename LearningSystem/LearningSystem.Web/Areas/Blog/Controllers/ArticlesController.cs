using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningSystem.Services.Articles;
using Microsoft.AspNetCore.Authorization;
using LearningSystem.Web.Areas.Blog.Models;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;
using LearningSystem.Web.Infrastructure.Extentions;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticlesService articles;
        private readonly UserManager<User> users;

        public ArticlesController(IArticlesService articles, UserManager<User> users)
        {
            this.articles = articles;
            this.users = users;
        }


        public async Task<IActionResult> Index()
        => View(await this.articles.All()); //todo: show the author in the view

        //todo: Make Authorize only for BlogAuthor role
        public async Task<IActionResult> Create()
        {
            return View(new AddArticleFormModel
            {
                PublishDate = DateTime.UtcNow
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var author = await this.users.GetUserAsync(HttpContext.User);

            await this.articles.CreateAsync
                (model.Title,
               model.Content,
               model.PublishDate,
               author.Id);

            TempData.AddSuccessMessage($"Congratulations, {author.UserName}! Article {model.Title} added successully.");

            return this.Redirect("/blog/articles/index");
        }
    }
}