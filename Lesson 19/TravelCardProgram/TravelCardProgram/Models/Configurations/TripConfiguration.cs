using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("trips_info");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.TripDate)
                .HasColumnName("trip_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.HasOne(item => item.Terminal)
                .WithMany(item => item.Trips)
                .HasForeignKey(item => item.TerminalId)
                .IsRequired();

            builder.HasOne(item => item.TravelCard)
                .WithMany(item => item.Trips)
                .HasForeignKey(item => item.TravelCardId)
                .IsRequired();
        }

    }
}
