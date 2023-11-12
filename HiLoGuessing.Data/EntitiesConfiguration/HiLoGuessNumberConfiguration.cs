using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiLoGuessing.Infrastructure.EntitiesConfiguration
{
    public class HiLoGuessNumberConfiguration : IEntityTypeConfiguration<HiLoGuess>
    {
        public void Configure(EntityTypeBuilder<HiLoGuess> builder)
        {
            builder.HasKey(h => h.HiLoGuessId);
            builder.Property(h => h.GeneratedMysteryNumber).IsRequired();

            builder.HasOne(h => h.Player)
                .WithOne(p => p.HiLoGuess)
                .HasForeignKey<Player>(p => p.HiLoGuessId);

            builder.HasOne(h => h.Attempts)
                .WithOne(a => a.HiLoGuess)
                .HasForeignKey<Attempts>(a => a.HiLoGuessId);
        }
    }
}
