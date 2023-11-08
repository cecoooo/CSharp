namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Performer>()
                .HasMany(x => x.PerformerSongs)
                .WithOne(x => x.Performer)
                .HasForeignKey(x => x.PerformerId);

            builder.Entity<Song>()
                .HasMany(x => x.SongPerformers)
                .WithOne(x => x.Song)
                .HasForeignKey(x => x.SongId);

            builder.Entity<SongPerformer>()
                .HasKey(x => new
            {
                x.SongId,
                x.PerformerId
            });

            builder.Entity<SongPerformer>()
                .Property(x => x.SongId)
            .IsRequired(true);

            builder.Entity<SongPerformer>()
                 .Property(x => x.PerformerId)
                .IsRequired(true);

            builder.Entity<SongPerformer>()
                .HasKey(x => new {
                x.PerformerId,
                x.SongId
            });
        }
    }
}
