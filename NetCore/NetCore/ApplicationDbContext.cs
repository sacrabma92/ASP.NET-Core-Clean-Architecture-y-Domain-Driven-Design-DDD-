using Microsoft.EntityFrameworkCore;
using NetCore.Entities;

namespace NetCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibroAutor>()
                .HasKey(xi => new { xi.AutorId, xi.LibroId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Libro> Libro { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<LibroAutor> LibroAutor { get; set; }
    }
}
