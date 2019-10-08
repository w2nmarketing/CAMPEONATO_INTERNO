using System;

namespace Campeonato.Entidades
{

    public class Jogos
    {

        public int Id { get; set; }

        public virtual Fases Fase { get; set; }

        public DateTime Data_Hora { get; set; }

        public virtual Times Time_1 { get; set; }

        public virtual Goleiros Goleiro_1 { get; set; }

        public int? Resultado_1 { get; set; }

        public virtual Times Time_2 { get; set; }

        public virtual Goleiros Goleiro_2 { get; set; }

        public int? Resultado_2 { get; set; }

        public Jogos()
        {
        }

    }
}
