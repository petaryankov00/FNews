using FNews.Services.Articles;
using FNews.ViewModels.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult UserArticles(string id,[FromQuery]int currentPage = 1)
        {
            var articles = articleService.GetById(id,currentPage);
            return View("All",articles);
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
                articleService.CreateArticle(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error","Home");
            }

            return RedirectToAction("All", "Articles");
        }
    }
}
