using Campeonato.Entidades;
using Campeonato.Entidades.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Campeonato.Infra
{
    public class CampeonatoContext : DbContext
    {

        public CampeonatoContext(DbContextOptions<CampeonatoContext> options) : base(options) { }

        public DbSet<Fases> Fases { get; set; }
        public DbSet<Goleiros> Goleiros { get; set; }
        public DbSet<GolsDoJogo> GolsDoJogo { get; set; }
        public DbSet<Jogadores> Jogadores { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Times> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new TimeMap());
            builder.ApplyConfiguration(new FaseMap());
            builder.ApplyConfiguration(new GoleiroMap());
            builder.ApplyConfiguration(new GolsDoJogoMap());
            builder.ApplyConfiguration(new JogadorMap());
            builder.ApplyConfiguration(new JogoMap());

        }


    }
}
