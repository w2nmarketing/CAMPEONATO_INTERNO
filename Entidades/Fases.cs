using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("tbl_fase")]
    public class Fases
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Categoria Categoria { get; set; }

        [StringLength(100)]
        [Required]
        public string Nome { get; set; }

        public Fases()
        {
        }

    }
}
