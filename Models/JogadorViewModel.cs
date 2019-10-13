namespace Campeonato.Models
{
    public class JogadorViewModel
    {

        public string Jogador { get; set; }
        public int Gols { get; set; }

        public JogadorViewModel(string jogador, int gols)
        {
            this.Jogador = jogador;
            this.Gols = gols;
        }

    }
}