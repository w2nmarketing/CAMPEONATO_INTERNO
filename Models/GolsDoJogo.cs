namespace Campeonato.Models
{
    public class GolsDoJogo
    {
        public int id { get; set; }

        public Jogos Jogo { get; set; }

        public Jogadores Jogador { get; set; }

        public int Gols { get; set; }

        public GolsDoJogo()
        {

        }

    }
}
