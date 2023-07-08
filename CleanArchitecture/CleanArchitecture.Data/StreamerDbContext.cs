using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Streamer;User ID=sa;Password=12345;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacion 1 a N Videos y Streamer
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relacion N a M Actor y Video
            modelBuilder.Entity<Video>()
                .HasMany(m => m.Actores)
                .WithMany(m => m.Videos)
                .UsingEntity<VideosActores>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }

        public DbSet<Streamer> Streamers { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Actor> Actor { get; set; }
    }
}
