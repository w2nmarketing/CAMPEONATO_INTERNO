using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    [Table("tbl_jogo")]
    public class Jogos
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Fases Fase { get; set; }

        [Required]
        public DateTime Data_Hora { get; set; }

        [Required]
        public virtual Times Time_1 { get; set; }

        [Required]
        public virtual Goleiros Goleiro_1 { get; set; }

        public int? Resultado_1 { get; set; }

        [Required]
        public virtual Times Time_2 { get; set; }

        [Required]
        public virtual Goleiros Goleiro_2 { get; set; }

        [Required]
        public int? Resultado_2 { get; set; }

        public Jogos()
        {
        }

    }
}
