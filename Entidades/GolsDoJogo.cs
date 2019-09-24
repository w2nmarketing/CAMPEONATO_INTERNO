using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("rel_jogo_gols")]
    public class GolsDoJogo
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Jogos Jogo { get; set; }

        [Required]
        public virtual Jogadores Jogador { get; set; }

        public int? Gols { get; set; }

        public GolsDoJogo()
        {

        }

    }
}
