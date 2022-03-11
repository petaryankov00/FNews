using FNews.Data.Common;
using FNews.Data.Models;
using FNews.ViewModels.Teams;
using System.Globalization;

namespace FNews.Services.Teams
{
    public class TeamService : ITeamService
    {
        private readonly IRepository repo;

        public TeamService(IRepository repo)
        {
            this.repo = repo;
        }

        public AllTeamsViewModel GetAll(AllTeamsViewModel query)
        {
            var teamsQuery = repo.All<Team>();

            if (query.League != null)
            {
                teamsQuery = teamsQuery
                    .Where(x => x.League.Name == query.League);
            }

            var totalTeams = teamsQuery.Count();

            var result = new AllTeamsViewModel 
            { 
                TotalTeams = totalTeams, 
                CurrentPage = query.CurrentPage,
                Leagues = this.GetLeaguesNames(),
                League = query.League,
            };

            var teams = teamsQuery
                .Select(x => new TeamDataViewModel
                {
                    Id = x.Id,
                    LogoUrl = x.LogoUrl,
                    Stadium = x.Stadium,
                    Manager = $"{x.Manager.FirstName} {x.Manager.LastName}",
                    Name = x.Name,
                    LeagueName = x.League.Name,
                    CityName = x.City.Name,
                    Year = x.Year.Value.ToString("yyyy",CultureInfo.InvariantCulture),
                })
                 .Skip((query.CurrentPage - 1) * AllTeamsViewModel.TeamsPerPage)
                 .Take(AllTeamsViewModel.TeamsPerPage)
                 .ToList(); 

            result.Teams.AddRange(teams);

            return result;
        }

        private List<string> GetLeaguesNames()
            => repo.All<League>()
            .Select(x => x.Name)
            .ToList();
    }
}
