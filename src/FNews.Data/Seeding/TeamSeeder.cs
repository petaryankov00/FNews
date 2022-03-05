using FNews.Data.Models;
using FNews.Data.Seeding.SeedModels;
using FNews.Global;
using Newtonsoft.Json;
using System.Globalization;

namespace FNews.Data.Seeding
{
    public class TeamSeeder : ISeeder
    {
        
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Teams.Any())
            {
                return;
            }

            await AddInBulgaria(dbContext, 1);
            await AddTeamsInLeagues(dbContext, 2, 39);
            await AddTeamsInLeagues(dbContext, 3, 140);
            await AddTeamsInLeagues(dbContext, 4, 61);
            await AddTeamsInLeagues(dbContext, 5, 78);
            await AddTeamsInLeagues(dbContext, 6, 135);
        }

        private async Task AddTeamsInLeagues(ApplicationDbContext dbContext, int dbLeagueId, int apiLeagueId)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add(GlobalConstants.ApiHeaderKey, GlobalConstants.ApiAuthToken);
            client.DefaultRequestHeaders.Add(GlobalConstants.ApiHeaderHost, GlobalConstants.ApiVersion);
            var response = await client.GetAsync($"https://v3.football.api-sports.io/teams?league={apiLeagueId}&season=2021");

            var json = await response.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<TeamSeedModel>(json);

            List<Team> teamsList = new List<Team>();

            foreach (var c in teams.Response)
            {
                var city = dbContext.Cities.FirstOrDefault(x => x.Name == c.Venue.City);

                if (city == null)
                {
                    city = new City { CountryId = dbLeagueId, Name = c.Venue.City };
                }

                var team = new Team
                {
                    LeagueId = dbLeagueId,
                    Name = c.Team.Name,
                    City = city,
                    Stadium = c.Venue.Name,
                    LogoUrl = c.Team.Logo,
                    Year = DateTime.ParseExact(c.Team.Founded.ToString(), "yyyy", CultureInfo.InvariantCulture)
                };

                teamsList.Add(team);
            }

            await dbContext.AddRangeAsync(teamsList);
        }

        private async Task AddInBulgaria(ApplicationDbContext dbContext, int leagueId)
        {
            await dbContext.Teams.AddAsync(new Team { Name = "Beroe",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Levski Sofia",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "CSKA Sofia",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Lokomotiv Sofia",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Slavia Sofia",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Tsarsko Selo",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Arda Kurdzhali",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Pirin Blagoevgrad",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Botev Vraca",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Cherno More",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Botev Plovdiv",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Lokomotiv Plovdiv",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "CSKA 1948",LeagueId = leagueId });
            await dbContext.Teams.AddAsync(new Team { Name = "Ludogorets Razgrad",LeagueId = leagueId });
        }



        
    }
}
