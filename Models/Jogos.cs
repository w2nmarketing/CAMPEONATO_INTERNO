using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Models
{

    [Table("tbl_jogo")]
    public class Jogos
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_Fase")]
        public Fases Fase { get; set; }

        public DateTime Data_Hora { get; set; }

        [Column("id_Time_1")]
        public Times Time_1 { get; set; }

        [Column("id_Goleiro_1")]
        public Goleiros Goleiro_1 { get; set; }

        public int Resultado_1 { get; set; }

        [Column("id_Time_2")]
        public Times Time_2 { get; set; }

        [Column("id_Goleiro_2")]
        public Goleiros Goleiro_2 { get; set; }

        public int Resultado_2 { get; set; }

        public Jogos()
        {
        }

    }
}
