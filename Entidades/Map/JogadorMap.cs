using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Entidades.Map
{
    public class JogadorMap : IEntityTypeConfiguration<Jogadores>
    {
        public void Configure(EntityTypeBuilder<Jogadores> builder)
        {

            builder.ToTable("rel_time_jogador");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Time).IsRequired();
            //builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");

        }
    }
}

