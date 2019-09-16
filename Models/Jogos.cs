using System;

namespace Campeonato.Models
{
    public class Jogos
    {

        public int id { get; set; }

        public Fases Fase { get; set; }

        public DateTime Data_Hora { get; set; }

        public Times Time_1 { get; set; }

        public Goleiros Goleiro_1 { get; set; }

        public int Resultado_1 { get; set; }

        public Times Time_2 { get; set; }

        public Goleiros Goleiro_2 { get; set; }

        public int Resultado_2 { get; set; }

        public Jogos()
        {
        }

    }
}
