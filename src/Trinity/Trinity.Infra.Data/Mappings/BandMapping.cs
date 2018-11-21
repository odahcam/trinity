using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinity.Domain.Model;

namespace Trinity.Infra.Data.Mappings
{
    public class BandMapping : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder.ToTable("Bands");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired();

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType(SqlDbType.DateTime.ToString())
                .IsRequired(false);

            builder.Property(b => b.Name)
                .HasColumnName("Name")
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(b => b.FoundationYear)
                .HasColumnName("FoundationYear")
                .HasColumnType(SqlDbType.SmallInt.ToString())
                .IsRequired();
        }
    }
}
