using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Context
{
    public class MysteryNumberDbContext : DbContext
    {
        public DbSet<MysteryNumber?> MysteryNumbers { get; set; }

        public MysteryNumberDbContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To configure Fluent API for Code-First
            // Been doing on EntitiesConfiguration
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MysteryNumberDbContext).Assembly);
        }
    }
}
