using System;
using System.Collections.Generic;

namespace Campeonato.Entidades
{

    public class Jogos
    {

        public int Id { get; set; }

        public int FaseId { get; set; }

                public virtual Fases Fase { get; set; }

        public DateTime Data_Hora { get; set; }

        public int Time_1Id { get; set; }

                public virtual Times Time_1 { get; set; }

        public int? Goleiro_1Id { get; set; }

                public virtual Goleiros Goleiro_1 { get; set; }

        public int? Resultado_1 { get; set; }

        public int Time_2Id { get; set; }
                public virtual Times Time_2 { get; set; }

        public int? Goleiro_2Id { get; set; }
                public virtual Goleiros Goleiro_2 { get; set; }

        public int? Resultado_2 { get; set; }
        public virtual ICollection<GolsDoJogo> GolsdoJogo { get; set; }

        public Jogos()
        {
        }

    }
}
