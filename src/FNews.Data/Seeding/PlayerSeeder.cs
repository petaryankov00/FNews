using FNews.Data.Models;
using FNews.Global;
using Newtonsoft.Json;

namespace FNews.Data.Seeding
{

    //TO DO: Finish the seed of all leagues.
    public class PlayerSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Players.Any())
            {
                return;
            }

            //await AddPlayers(dbContext, 39); DONE
            //await AddPlayers(dbContext, 140); DONE
            //await AddPlayers(dbContext, 61); DONE
            //await AddPlayers(dbContext, 78);

        }

        private async Task AddPlayers(ApplicationDbContext dbContext, int apiLeagueId)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add(GlobalConstants.ApiHeaderKey, GlobalConstants.ApiAuthToken);
            client.DefaultRequestHeaders.Add(GlobalConstants.ApiHeaderHost, GlobalConstants.ApiVersion);

            List<Player> players = new List<Player>();
            
            for (int i = 1; i <= 39; i++)
            {
                if (i % 10 == 0)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(60));
                }

                var response = await client.GetAsync($"https://v3.football.api-sports.io/players?league={apiLeagueId}&season=2021&page={i}");

                var json = await response.Content.ReadAsStringAsync();

                var playersData = JsonConvert.DeserializeObject<PlayerSeedModel>(json);

                foreach (var p in playersData.Response)
                {

                    var country = dbContext.Countries.FirstOrDefault(x => x.Name == p.Player.Nationality);

                    if (country == null)
                    {
                        country = new Country { Name = p.Player.Nationality };
                    }
                     
                    DateTime.TryParse(p.Player.Birth.Date, out var date);

                    var player = dbContext.Players
                        .FirstOrDefault(x => x.FirstName == p.Player.Firstname && x.LastName == p.Player.Lastname);

                    if (player != null)
                    {
                        continue;
                    }

                    player = new Player
                    {
                        FirstName = p.Player.Firstname,
                        LastName = p.Player.Lastname,
                        BirthDate = date,
                        PhotoUrl = p.Player.Photo,
                        Country = country,
                        
                    };

                    foreach (var s in p.Statistics)
                    {
                        player.Position = s.Games.Position;
                        player.Team = dbContext.Teams.FirstOrDefault(x => x.Name == s.Team.Name);
                    }

                    players.Add(player);
                }
            }

            await dbContext.AddRangeAsync(players);

        }
    }
}
