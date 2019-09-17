using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Models
{

    [Table("rel_jogo_gols")]
    public class GolsDoJogo
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_Jogo")]
        public Jogos Jogo { get; set; }

        [Column("id_Jogador")]
        public Jogadores Jogador { get; set; }

        public int Gols { get; set; }

        public GolsDoJogo()
        {

        }

    }
}
