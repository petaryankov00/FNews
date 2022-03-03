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

        public DbSet<News> News { get; init; }

        public DbSet<TeamsNews> TeamsNews { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamsNews>()
                .HasKey(k => new { k.TeamId, k.NewsId });

            builder.Entity<TeamsNews>()
                .HasOne(x => x.Team)
                .WithMany(x => x.TeamsNews)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TeamsNews>()
                .HasOne(x => x.News)
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


            base.OnModelCreating(builder);
        }
    }
}