using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HiLoGuessing.Infrastructure.Context
{
    public class MysteryNumberDbContext : DbContext
    {
        public DbSet<HiLoGuess> HiLoGuess { get; set; }
        public DbSet<Attempts> Attempts { get; set; }

        public MysteryNumberDbContext(DbContextOptions<MysteryNumberDbContext> options)
            : base(options)
        {
        }

        //private readonly IConfiguration _configuration;

        //public MysteryNumberDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To configure Fluent API for Code-First
            // Been doing on EntitiesConfiguration
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MysteryNumberDbContext).Assembly);
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connection = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        //    options.UseSqlServer(connection);
        //}
    }
}
