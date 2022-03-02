using FNews.Data.Models;

namespace FNews.Data.Seeding
{
    public class CitySeeder : ISeeder
    {
        public async Task SeedAsync(FNewsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            await AddInBulgaria(1, dbContext);

            await AddInEngland(2, dbContext);

            await AddInSpain(3, dbContext);
           
            await AddInFrance(4, dbContext);
            
            await AddInGermany(5, dbContext);

            await AddInItaly(6, dbContext);
            
        }

        private async Task AddInBulgaria(int countryId, FNewsDbContext dbContext)
        {
            await dbContext.Cities.AddAsync(new City { Name = "Sofia", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Plovdiv", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Stara Zagora", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Varna", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Blagoevgrad", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Vraca", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Kurdzhali", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Razgrad", CountryId = countryId });

        }

        private async Task AddInItaly(int countryId, FNewsDbContext dbContext)
        {
            await dbContext.Cities.AddAsync(new City { Name = "Bergamo", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Bologna", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Cagliari", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Empoli", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Florence", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Genoa", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Verona", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Milan", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Turin", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Rome", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Naples", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Salerno", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Genoa", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Sassuolo", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "La Spezia", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Udine", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Venice", CountryId = countryId });
        }

        private async Task AddInGermany(int countryId, FNewsDbContext dbContext)
        {
            await dbContext.Cities.AddAsync(new City { Name = "Dortmund", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Bielefeld", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Augsburg", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Leverkusen", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Munich", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Bochum", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Mönchengladbach", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Frankfurt", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Freiburg im Breisgau", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Fürth", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Berlin", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Sinsheim", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Cologne", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Leipzig", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Mainz", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Stuttgart", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Wolfsburg", CountryId = countryId });
        }

        private async Task AddInFrance(int countryId, FNewsDbContext dbContext)
        {

            await dbContext.Cities.AddAsync(new City { Name = "Paris", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Brest", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Lorient", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Nantes", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Angers", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Rennes", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Bordeaux", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Lens", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Lille", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Reims", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Metz", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Troyes", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Strasbourg", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Clermont-Ferrand", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Lyon", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Saint-Étienne", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Monaco", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Montpellier", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Marseille", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Nice", CountryId = countryId });
        }

        private async Task AddInSpain(int countryId,FNewsDbContext dbContext)
        {
            await dbContext.Cities.AddAsync(new City { Name = "Barcelona", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Madrid", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Vitoria-Gasteiz", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Bilbao", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Cádiz", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Vigo", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Elche", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Cornellà de Llobregat", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Granada", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Valencia", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Palma", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Pamplona", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Seville", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "San Sebastián", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Villarreal", CountryId = countryId });
        }

        private async Task AddInEngland(int countryId,FNewsDbContext dbContext)
        {
            await dbContext.Cities.AddAsync(new City { Name = "London", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Liverpool", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Birmingham", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Brighton", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Burnley", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Leeds", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Leicester", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Manchester", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Newcastle upon Tyne", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Norwich", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Southampton", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Watford", CountryId = countryId });
            await dbContext.Cities.AddAsync(new City { Name = "Wolverhampton", CountryId = countryId });

        }
    }
}
