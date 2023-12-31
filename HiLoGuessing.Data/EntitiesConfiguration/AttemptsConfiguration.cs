﻿using HiloGuessing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiLoGuessing.Infrastructure.EntitiesConfiguration
{
    public class AttemptsConfiguration : IEntityTypeConfiguration<Attempts>
    {
        public void Configure(EntityTypeBuilder<Attempts> builder)
        {
            builder.HasKey(a => a.AttemptsId);

            builder.HasOne(a => a.HiLoGuess)
                .WithOne(h => h.Attempts)
                .HasForeignKey<Attempts>(a => a.HiLoGuessId);
        }
    }
}
