using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.ToTable("tariffs");

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

            builder.Property(item => item.UndergroundTripPrice)
                .HasColumnName("underground_trip_price")
                .HasColumnType("decimal");

            builder.Property(item => item.GroundTripPrice)
                .HasColumnName("ground_trip_price")
                .HasColumnType("decimal");

            builder.Property(item => item.Duration)
                .HasColumnName("duration")
                .HasColumnType("int");

            builder.HasMany(item => item.TravelCards)
                .WithOne(item => item.Tariff)
                .HasForeignKey(item => item.TariffId)
                .IsRequired();

        }
        
    }
}
