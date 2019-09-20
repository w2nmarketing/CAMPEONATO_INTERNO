using Campeonato.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Campeonato.Infra
{
    public class CampeonatoContext : DbContext
    {

        public DbSet<Times> Times { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Goleiros> Goleiros { get; set; }
        public DbSet<Jogadores> Jogadores { get; set; }
        public DbSet<Fases> Fases { get; set; }
        public DbSet<GolsDoJogo> GolsDoJogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            string stringConexao = configuration.GetConnectionString("Campeonato");

            optionsBuilder.UseMySql(stringConexao);

        }


    }
}
