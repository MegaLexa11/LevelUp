using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("rates");

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

            builder.Property(item => item.Duration)
                .HasColumnName("duration")
                .HasColumnType("int");

            // Тут, походу, что-то не так
            builder.HasOne(item => item.Trip)
                .WithMany(item => item.Rates)
                .HasForeignKey(item => item.UndergroundTripId)
                .IsRequired();

            builder.HasOne(item => item.Trip)
                .WithMany(item => item.Rates)
                .HasForeignKey(item => item.GroundTripId)
                .IsRequired();
        }
        
    }
}
