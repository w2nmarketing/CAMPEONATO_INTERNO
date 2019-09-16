using Campeonato.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Campeonato.Infra
{
    public class CampeonatoContext : DbContext
    {

        // DbSet < NOME_DA_CLASS > NOME_DA_TABELA 

        public DbSet<Times> Times { get; set; }

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
