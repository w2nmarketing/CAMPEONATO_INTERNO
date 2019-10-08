using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Entidades.Map
{
    public class JogoMap : IEntityTypeConfiguration<Jogos>
    {
        public void Configure(EntityTypeBuilder<Jogos> builder)
        {

            builder.ToTable("tbl_jogo");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Fase).IsRequired();
            //builder.Property(x => x.Data_Hora).IsRequired();
            //builder.Property(x => x.Time_1).IsRequired();
            //builder.Property(x => x.Goleiro_1).IsRequired();
            //builder.Property(x => x.Resultado_1).IsRequired().HasMaxLength(2).HasColumnType("smallint");
            //builder.Property(x => x.Time_2).IsRequired();
            //builder.Property(x => x.Goleiro_2).IsRequired();
            //builder.Property(x => x.Resultado_2).IsRequired().HasMaxLength(2).HasColumnType("smallint");

        }
    }
}
