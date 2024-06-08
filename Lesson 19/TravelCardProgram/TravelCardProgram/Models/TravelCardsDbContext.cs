using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCardProgram.Models.Configurations;

namespace TravelCardProgram.Models
{
    internal class TravelCardsDbContext : DbContext
    {
        public DbSet<TravelCard> TravelCards { get; set; } = default!;
        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Rate> Rates { get; set; } = default!;
        public DbSet<TripInfo> Trips { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        public TravelCardsDbContext(DbContextOptions<TravelCardsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TravelCardConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RateConfiguration());
            modelBuilder.ApplyConfiguration(new TripInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
