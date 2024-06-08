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
            builder.ToTable("trips");

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

            builder.Property(item => item.ExpirationDate)
                .HasColumnName("expiration_date")
                .HasColumnType("datetime");

            builder.HasOne(item => item.User)
                .WithMany(item => item.TravelCards)
                .HasForeignKey(item => item.UserId)
                .IsRequired();

            builder.HasOne(item => item.Rate)
                .WithMany(item => item.TravelCards)
                .HasForeignKey(item => item.RateId)
                .IsRequired();

            // Тут что-то не так
            builder.HasOne(item => item.Account)
                .WithOne(item => item.TravelCard)
                .HasForeignKey<Account>(item => item.TravelCardId)
                .IsRequired();

        }
    }
}
