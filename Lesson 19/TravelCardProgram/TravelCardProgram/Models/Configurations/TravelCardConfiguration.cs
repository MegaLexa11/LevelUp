using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class TravelCardConfiguration : IEntityTypeConfiguration<TravelCard>
    {
        public void Configure(EntityTypeBuilder<TravelCard> builder)
        {
            builder.ToTable("travel_cards");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.Number)
                .HasColumnName("number")
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(item => item.ActivationDate)
                .HasColumnName("activation_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(item => item.ExpirationDate)
                .HasColumnName("expiration_date")
                .HasColumnType("timestamp");

            builder.Property(item => item.Status)
                .HasColumnName("status")
                .HasColumnType("int")
                .IsRequired(); ;

            builder.HasOne(item => item.Passenger)
                .WithMany(item => item.TravelCards)
                .HasForeignKey(item => item.PassengerId)
                .IsRequired();

            builder.HasOne(item => item.Tariff)
                .WithMany(item => item.TravelCards)
                .HasForeignKey(item => item.TariffId)
                .IsRequired();
        }
    }
}
