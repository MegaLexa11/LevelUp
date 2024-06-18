using Microsoft.EntityFrameworkCore;
using TravelCardProgram.Models.Configurations;

namespace TravelCardProgram.Models
{
    internal class TravelCardsDbContext : DbContext
    {
        public DbSet<TravelCard> TravelCards { get; set; } = default!;
        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Tariff> Tariffs { get; set; } = default!;
        public DbSet<Trip> Trips { get; set; } = default!;
        public DbSet<Passenger> Passengers { get; set; } = default!;
        public DbSet<Terminal> Terminals { get; set; } = default!;
        public DbSet<Coefficient> Coefficients { get; set; } = default!;


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
            modelBuilder.ApplyConfiguration(new TripConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new CoefficientConfiguration());
            modelBuilder.ApplyConfiguration(new TerminalConfiguration());
        }
    }
}
