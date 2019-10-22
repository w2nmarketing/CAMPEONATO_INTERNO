using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations;

namespace Campeonato.Entidades
{
    public class Classificacao
    {

        [Key]
        public int Id_Time { get; set; }
        public int Jogos { get; set; }
        public int Total_Pontos { get; set; }
        public int Total_Vitorias { get; set; }
        public int Total_Empates { get; set; }
        public int Total_Derrotas { get; set; }
        public int Saldo_Gols { get; set; }
        public int Gols_Marcados { get; set; }
        public int Gols_Sofridos { get; set; }
        public string Nome { get; set; }
        public string Escudo { get; set; }
        public Categoria Categoria { get; set; }

    }
}