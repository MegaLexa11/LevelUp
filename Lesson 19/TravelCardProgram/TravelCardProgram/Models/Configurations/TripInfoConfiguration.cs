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
    internal class TripInfoConfiguration : IEntityTypeConfiguration<TripInfo>
    {
        public void Configure(EntityTypeBuilder<TripInfo> builder)
        {
            builder.ToTable("trips_info");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.TransportType)
                .HasColumnName("transport_type")
                .HasColumnType("int")
                .IsRequired();
        }

    }
}
