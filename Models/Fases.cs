using Campeonato.Entidades.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Models
{

    [Table("tbl_fase")]
    public class Fases
    {

        [Column("id")]
        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public Fases()
        {

        }

    }
}
