using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Models
{

    [Table("tbl_goleiro")]
    public class Goleiros
    {

        [Column("id")]
        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public Goleiros()
        {

        }

    }
}
