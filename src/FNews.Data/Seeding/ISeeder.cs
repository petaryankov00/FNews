namespace FNews.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(FNewsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
