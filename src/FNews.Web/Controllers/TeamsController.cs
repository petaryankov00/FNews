using FNews.Services.Teams;
using FNews.ViewModels.Teams;
using Microsoft.AspNetCore.Mvc;

namespace FNews.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public IActionResult All([FromQuery] AllTeamsViewModel query)
        {
            var teams = teamService.GetAll(query);

            return View(teams);
        }
    }
}
