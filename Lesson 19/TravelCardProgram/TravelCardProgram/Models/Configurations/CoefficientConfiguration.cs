using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class CoefficientConfiguration : IEntityTypeConfiguration<Coefficient>
    {
        public void Configure(EntityTypeBuilder<Coefficient> builder)
        {
            builder.ToTable("coefficients");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(item => item.Value)
                .HasColumnName("value")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(item => item.durationMinutes)
                .HasColumnName("duration_minutes")
                .HasColumnType("int");

        }
    }
}
