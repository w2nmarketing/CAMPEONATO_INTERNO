using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Models
{

    [Table("rel_time_jogador")]
    public class Jogadores
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_Time")]
        public Times Time { get; set; }

        public string Nome { get; set; }

        public Jogadores()
        {

        }

    }
}
