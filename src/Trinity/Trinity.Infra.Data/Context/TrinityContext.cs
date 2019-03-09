using Microsoft.EntityFrameworkCore;
using Trinity.Domain.Model;
using Trinity.Infra.Data.Mappings;

namespace Trinity.Infra.Data.Context
{
    public class TrinityContext : DbContext, IDbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;"
              + @"AttachDbFilename=C:\Users\Tyler\Documents\Trinity.mdf;"
              + "Integrated Security=True;Connect Timeout=30"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicMapping());
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new BandMapping());
        }

    }
}
