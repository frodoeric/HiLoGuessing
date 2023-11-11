﻿// <auto-generated />
using System;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    [DbContext(typeof(MysteryNumberDbContext))]
    [Migration("20231111152644_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("HiLoGuessing.Infrastructure.Attempts", b =>
                {
                    b.Property<Guid>("AttemptsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HiLoGuessId")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfAttempts")
                        .HasColumnType("INTEGER");

                    b.HasKey("AttemptsId");

                    b.HasIndex("HiLoGuessId")
                        .IsUnique();

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.HiLoGuess", b =>
                {
                    b.Property<Guid>("HiLoGuessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneratedMysteryNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("HiLoGuessId");

                    b.ToTable("HiLoGuess");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.Attempts", b =>
                {
                    b.HasOne("HiLoGuessing.Infrastructure.HiLoGuess", "HiLoGuess")
                        .WithOne("Attempts")
                        .HasForeignKey("HiLoGuessing.Infrastructure.Attempts", "HiLoGuessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HiLoGuess");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.HiLoGuess", b =>
                {
                    b.Navigation("Attempts")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}