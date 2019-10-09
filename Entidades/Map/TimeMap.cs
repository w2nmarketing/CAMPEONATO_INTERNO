using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Campeonato.Entidades.Map
{
    public class TimeMap : IEntityTypeConfiguration<Times>
    {
        public void Configure(EntityTypeBuilder<Times> builder)
        {

            builder.ToTable("tbl_time");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Categoria).IsRequired();
            //builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            //builder.Property(x => x.Escudo).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");

        }
    }
}



