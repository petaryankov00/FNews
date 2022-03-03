using AngleSharp.Html.Parser;
using FNews.Data.Models;

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
            await AddInEngland(dbContext, 2);
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

        private async Task AddInEngland(ApplicationDbContext dbContext, int leagueId)
        {
            var client = new HttpClient();
            var responseBody = await client.GetStringAsync("https://www.premierleague.com/clubs");

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(responseBody);

            var names = document.QuerySelectorAll("h4.clubName").ToList();
            var stadiums = document.QuerySelectorAll("div.stadiumName").ToList();

            for (int i = 0; i < 20; i++)
            {
                var currName = names[i];
                var currStadium = stadiums[i];
                dbContext.Teams.Add(new Team 
                { 
                    Name = currName.InnerHtml, 
                    Stadium = currStadium.InnerHtml, 
                    LeagueId = leagueId 
                });
            }
        }
    }
}
