namespace UndergroundStation.Web.Areas.Forum.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Services.Forum;
    using Models.Sections;
    using Infrastructure.Extentions;

    using static WebConstants;

    [Area(ForumArea)]
    public class SectionsController : Controller
    {
        private readonly ISectionsService sections;
        private readonly IThemesService themes;

        public SectionsController
            (ISectionsService sections,
            IThemesService themes)
        {
            this.sections = sections;
            this.themes = themes;
        }

        [Authorize(Roles = ForumModeratorRole)]
        public IActionResult Create()
           => View();

        [Authorize(Roles = ForumModeratorRole)]
        [HttpPost]
        public async Task<IActionResult> Create(SectionCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (model.Description == null || model.Title == null)
            {
                return BadRequest();
            }

            var success = await sections.Create(model.Title, model.Description);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Article {model.Title} successfully published.");

            return   Redirect("/Forum/Home/Index");
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var section = await sections.ById(id);

            return View(section);
        }
       
    }
}
