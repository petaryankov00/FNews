using FNews.Services.News;
using Microsoft.AspNetCore.Mvc;

namespace FNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRssNewsService newsService;
        public HomeController(IRssNewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var news = newsService.GetMainNews();
            return View(news);
        }
    }
}