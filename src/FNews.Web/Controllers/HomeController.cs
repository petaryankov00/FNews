using Microsoft.AspNetCore.Mvc;

namespace FNews.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}