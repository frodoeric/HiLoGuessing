using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiLoGuessing.Infrastructure.EntitiesConfiguration
{
    public class MysteryNumberConfiguration : IEntityTypeConfiguration<HiLoGuess>
    {
        public void Configure(EntityTypeBuilder<HiLoGuess> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.GeneratedMysteryNumber).HasMaxLength(100);
        }
    }
}
