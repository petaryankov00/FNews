using System.ComponentModel.DataAnnotations;

namespace FNews.ViewModels.Teams
{
    public class AllTeamsViewModel
    {
        public const int TeamsPerPage = 4;

        public int CurrentPage { get; set; } = 1;

        public int TotalTeams { get; set; }

        public List<string> Leagues { get; init; }

        [Display(Name = "Search by League")]
        public string League { get; set; }

        public List<TeamDataViewModel> Teams { get; set; } = new List<TeamDataViewModel>();

    }
}
