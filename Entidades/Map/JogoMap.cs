using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campeonato.Entidades.Map
{
    public class JogoMap : IEntityTypeConfiguration<Jogos>
    {
        public void Configure(EntityTypeBuilder<Jogos> builder)
        {

            builder.ToTable("tbl_jogo");
            builder.HasKey(x => x.Id);

            builder.HasOne(j => j.Fase).WithMany(g => g.Jogos).HasForeignKey(j => j.FaseId);

            builder.HasOne(j => j.Time_1).WithMany(g => g.Jogos1).HasForeignKey(j => j.Time_1Id);
            builder.HasOne(j => j.Time_2).WithMany(g => g.Jogos2).HasForeignKey(j => j.Time_2Id);

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
