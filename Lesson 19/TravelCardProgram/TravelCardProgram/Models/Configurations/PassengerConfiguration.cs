using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable("passengers");

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

            builder.HasMany(item => item.TravelCards)
                .WithOne(item => item.Passenger)
                .HasForeignKey(item => item.PassengerId);
        }
    }
}
