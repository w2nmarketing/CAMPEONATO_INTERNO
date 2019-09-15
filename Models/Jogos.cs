using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Models
{
    public class Jogos
    {

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
