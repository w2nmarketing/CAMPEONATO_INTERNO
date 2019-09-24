using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("tbl_goleiro")]
    public class Goleiros
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Categoria Categoria { get; set; }

        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        public Goleiros()
        {
        }

    }
}
