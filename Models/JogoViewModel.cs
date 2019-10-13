using System.Collections.Generic;

namespace Campeonato.Models
{
    public class JogoViewModel
    {

        public string Categoria { get; set; }
        public string Fase { get; set; }
        public string Data_Hora { get; set; }

        public string Escudo_1 { get; set; }
        public string Time_1 { get; set; }
        public int Resultado_1 { get; set; }
        public List<JogadorViewModel> Jogadores_1 { get; set; }

        public string Escudo_2 { get; set; }
        public string Time_2 { get; set; }
        public int Resultado_2 { get; set; }
        public List<JogadorViewModel> Jogadores_2 { get; set; }

        public JogoViewModel()
        {
            Jogadores_1 = new List<JogadorViewModel>();
            Jogadores_2 = new List<JogadorViewModel>();
        }

    }
}