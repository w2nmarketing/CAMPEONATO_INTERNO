using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Models
{
    public class GolsDoJogo
    {

        public Jogos Jogo { get; set; }
        public Jogadores Jogador { get; set; }
        public int Gols { get; set; }

        public Gols()
        {

        }

    }
}
