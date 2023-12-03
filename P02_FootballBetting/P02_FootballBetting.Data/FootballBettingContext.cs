using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        const string connectionString = @"--Set_Your_Connection_String--";

        public DbSet<Team> Teams { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(x => new
                {
                    x.PlayerId,
                    x.GameId
                });
        }
    }
}
