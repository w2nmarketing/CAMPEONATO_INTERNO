namespace Campeonato.Entidades
{

    public class GolsDoJogo
    {

        public int Id { get; set; }

        public int JogoId { get; set; }

                    public virtual Jogos Jogo { get; set; }

        public int JogadorId { get; set; }

                    public virtual Jogadores Jogador { get; set; }

        public int? Gols { get; set; }

        public GolsDoJogo()
        {
        }

    }
}
