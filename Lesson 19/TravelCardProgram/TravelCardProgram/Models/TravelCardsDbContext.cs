﻿using Microsoft.EntityFrameworkCore;
using TravelCardProgram.Models.Configurations;

namespace TravelCardProgram.Models
{
    internal class TravelCardsDbContext : DbContext
    {
        public DbSet<TravelCard> TravelCards { get; set; } = default!;
        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Tariff> Rates { get; set; } = default!;
        public DbSet<TripInfo> Trips { get; set; } = default!;
        public DbSet<Passenger> Users { get; set; } = default!;

        public TravelCardsDbContext(DbContextOptions<TravelCardsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TravelCardConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TariffConfiguration());
            modelBuilder.ApplyConfiguration(new TripInfoConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        }
    }
}
