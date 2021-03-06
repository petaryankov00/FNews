using FNews.Services.Articles;
using FNews.ViewModels.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FNews.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult All(int currentPage = 1)
        {
            var articles = articleService.GetAll(currentPage);
            return this.View(articles);
        }

        [Authorize]
        public IActionResult UserArticles(string id,[FromQuery]int currentPage = 1)
        {
            var articles = articleService.GetById(id,currentPage);
            string value = this.HttpContext.Request.Path.Value
                .Split("/")
                .Skip(2)
                .Take(1)
                .FirstOrDefault();
            ViewData["Path"] = value;

            return View("All",articles);
        }

        public IActionResult Details(string id)
        {
            var article = articleService.GetDetails(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [Authorize]
        public IActionResult Create()
        {
            var teams = articleService.GetTeamNames();
            return this.View(teams);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateArticleInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var teams = articleService.GetTeamNames();
                return this.View(teams);
            }

            try
            {
                articleService.Create(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error","Home");
            }

            return RedirectToAction("All", "Articles");
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var articleDetails = articleService.GetDetails(id);

            if (this.User.FindFirst(ClaimTypes.NameIdentifier).Value != articleDetails.AuthorId)
            {
                return Unauthorized();
            }

            var article = articleService.GetForEdit(articleDetails);

            return View(article);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(string id,CreateArticleInputModel model)
        {
            var isEdited = articleService.Edit(id, model);

            if (!isEdited)
            {
                return BadRequest();
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}
