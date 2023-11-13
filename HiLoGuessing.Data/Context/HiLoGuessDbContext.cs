using HiloGuessing.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Context
{
    public class HiLoGuessDbContext : IdentityDbContext<User>
    {
        public DbSet<HiLoGuess> HiLoGuess { get; set; }
        public DbSet<Attempts> Attempts { get; set; }
        public DbSet<Player> Players { get; set; }

        public HiLoGuessDbContext(DbContextOptions<HiLoGuessDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To configure Fluent API for Code-First
            // Been doing on EntitiesConfiguration
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HiLoGuessDbContext).Assembly);
        }
    }
}
