﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Context
{
    public class MysteryNumberDbContext : DbContext
    {
        public DbSet<MysteryNumber> MysteryNumbers { get; set; }
        public DbSet<Attempt> Attempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // To configure Fluent API for Code-First
            // Been doing on EntitiesConfiguration
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MysteryNumberDbContext).Assembly);
        }

        //// The following configures EF to create a Sqlite database file in the
        //// special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "hilo.db");

            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
