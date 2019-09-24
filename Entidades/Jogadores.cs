using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("rel_time_jogador")]
    public class Jogadores
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Times Time { get; set; }

        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        public Jogadores()
        {

        }

    }
}
