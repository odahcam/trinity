using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinity.Domain.Model;

namespace Trinity.Infra.Data.Mappings
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired();

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired(false);

            builder.Property(a => a.Title)
                .HasColumnName("Title")
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
