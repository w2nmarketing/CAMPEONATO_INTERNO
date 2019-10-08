using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Entidades.Map
{
    public class GolsDoJogoMap : IEntityTypeConfiguration<GolsDoJogo>
    {
        public void Configure(EntityTypeBuilder<GolsDoJogo> builder)
        {

            builder.ToTable("rel_jogo_gols");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Jogo).IsRequired();
            ////builder.Property(x => x.Jogador).IsRequired();
            //builder.Property(x => x.Gols).HasMaxLength(2).HasColumnType("smallint");

        }
    }
}




