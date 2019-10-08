using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Entidades.Map
{
    public class GoleiroMap : IEntityTypeConfiguration<Goleiros>
    {
        public void Configure(EntityTypeBuilder<Goleiros> builder)
        {

            builder.ToTable("tbl_goleiro");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Categoria).IsRequired();
            //builder.Property(x => x.Nome).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");

        }
    }
}




