using FNews.Data.Models;

namespace FNews.Data.Seeding
{
    public class CountrySeeder : ISeeder
    {
        public async Task SeedAsync(FNewsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            await dbContext.Countries.AddAsync(new Country { Name = "Bulgaria" });
            await dbContext.Countries.AddAsync(new Country { Name = "England" });
            await dbContext.Countries.AddAsync(new Country { Name = "Spain" });
            await dbContext.Countries.AddAsync(new Country { Name = "France" });
            await dbContext.Countries.AddAsync(new Country { Name = "Germany" });
            await dbContext.Countries.AddAsync(new Country { Name = "Italy" });
        }
    }
}
