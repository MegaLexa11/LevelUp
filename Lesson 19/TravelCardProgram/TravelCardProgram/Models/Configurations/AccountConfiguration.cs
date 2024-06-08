using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.Balance)
                .HasColumnName("Balance")
                .HasColumnType("float");

            // Тут что-то не так
            builder.HasOne(item => item.TravelCard)
                .WithOne(item => item.Account)
                .HasForeignKey<Account>(item => item.TravelCardId)
                .IsRequired();

        }
    }
}
