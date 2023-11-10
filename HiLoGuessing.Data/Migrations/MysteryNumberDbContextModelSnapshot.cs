﻿// <auto-generated />
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HiLoGuessing.Infrastructure.Migrations
{
    [DbContext(typeof(MysteryNumberDbContext))]
    partial class MysteryNumberDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("HiLoGuessing.Infrastructure.Attempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttemptedNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MysteryNumberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MysteryNumberId");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.HiLoGuess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratedMysteryNumber")
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfAttempts")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("HiLoGuess");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.Attempt", b =>
                {
                    b.HasOne("HiLoGuessing.Infrastructure.HiLoGuess", "HiLoGuess")
                        .WithMany("Attempts")
                        .HasForeignKey("MysteryNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HiLoGuess");
                });

            modelBuilder.Entity("HiLoGuessing.Infrastructure.HiLoGuess", b =>
                {
                    b.Navigation("Attempts");
                });
#pragma warning restore 612, 618
        }
    }
}
