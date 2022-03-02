using FNews.Data.Models;

namespace FNews.Data.Seeding
{
    public class LeagueSeeder : ISeeder
    {
        public async Task SeedAsync(FNewsDbContext dbContext, IServiceProvider serviceProvider)
        {
           await dbContext.Leagues.AddAsync(new League { Name = "First Professional League", CountryId = 1 });
           await dbContext.Leagues.AddAsync(new League { Name = "Premier League", CountryId = 2 });
           await dbContext.Leagues.AddAsync(new League { Name = "La Liga", CountryId = 3 });
           await dbContext.Leagues.AddAsync(new League { Name = "Ligue 1", CountryId = 4 });
           await dbContext.Leagues.AddAsync(new League { Name = "Bundensliga", CountryId = 5 });
           await dbContext.Leagues.AddAsync(new League { Name = "Seria A", CountryId = 6 });
        }
    }
}
