using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder)
        {
            builder.ToTable("terminals");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.TransportType)
                .HasColumnName("transport_type")
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany(item => item.Trips)
                .WithOne(item => item.Terminal)
                .HasForeignKey(item => item.TerminalId);
        }
    }
}
