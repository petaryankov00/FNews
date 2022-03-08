using FNews.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FNews.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; init; }

        public DbSet<Player> Players { get; init; }

        public DbSet<League> Leagues { get; init; }

        public DbSet<Country> Countries { get; init; }

        public DbSet<City> Cities { get; init; }

        public DbSet<Manager> Managers { get; init; }

        public DbSet<Article> Articles { get; init; }

        public DbSet<TeamsArticles> TeamsNews { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamsArticles>()
                .HasKey(k => new { k.TeamId, k.ArticleId });

            builder.Entity<TeamsArticles>()
                .HasOne(x => x.Team)
                .WithMany(x => x.TeamsArticles)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TeamsArticles>()
                .HasOne(x => x.Article)
                .WithMany(x => x.TeamsNews)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Team>()
                .HasMany(x => x.Users);

            builder.Entity<Team>()
                .HasOne(x => x.League)
                .WithMany(x => x.Teams)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Player>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Manager>()
                .HasOne(x => x.Team)
                .WithOne(x => x.Manager)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasOne(x => x.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}