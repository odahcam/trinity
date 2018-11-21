using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinity.Domain.Model;

namespace Trinity.Infra.Data.Mappings
{
    public class MusicMapping : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Musics");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired();

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired(false);

            builder.Property(m => m.Title)
                .HasColumnName("Title")
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.Duration)
                .HasColumnName("DurationTicks")
                .HasColumnType(SqlDbType.BigInt.ToString())
                .IsRequired();

            builder.HasOne(m => m.Album)
                .WithMany(a => a.Musics)
                .HasForeignKey(m => m.AlbumId)
                .IsRequired(false);


            builder.HasOne(m => m.Band)
                .WithMany(b => b.Musics)
                .HasForeignKey(m => m.BandId)
                .IsRequired();
        }
    }
}
