﻿// <auto-generated />
using System;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    [DbContext(typeof(HiLoGuessDbContext))]
    [Migration("20231112193143_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HiloGuessing.Domain.Entities.Attempts", b =>
                {
                    b.Property<Guid>("AttemptsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HiLoGuessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfAttempts")
                        .HasColumnType("int");

                    b.HasKey("AttemptsId");

                    b.HasIndex("HiLoGuessId")
                        .IsUnique();

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("HiloGuessing.Domain.Entities.HiLoGuess", b =>
                {
                    b.Property<Guid>("HiLoGuessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GeneratedMysteryNumber")
                        .HasColumnType("int");

                    b.HasKey("HiLoGuessId");

                    b.ToTable("HiLoGuess");
                });

            modelBuilder.Entity("HiloGuessing.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HiLoGuessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.HasIndex("HiLoGuessId")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("HiloGuessing.Domain.Entities.Attempts", b =>
                {
                    b.HasOne("HiloGuessing.Domain.Entities.HiLoGuess", "HiLoGuess")
                        .WithOne("Attempts")
                        .HasForeignKey("HiloGuessing.Domain.Entities.Attempts", "HiLoGuessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HiLoGuess");
                });

            modelBuilder.Entity("HiloGuessing.Domain.Entities.Player", b =>
                {
                    b.HasOne("HiloGuessing.Domain.Entities.HiLoGuess", "HiLoGuess")
                        .WithOne("Player")
                        .HasForeignKey("HiloGuessing.Domain.Entities.Player", "HiLoGuessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HiLoGuess");
                });

            modelBuilder.Entity("HiloGuessing.Domain.Entities.HiLoGuess", b =>
                {
                    b.Navigation("Attempts")
                        .IsRequired();

                    b.Navigation("Player")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
