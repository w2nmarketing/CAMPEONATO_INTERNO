using Campeonato.Entidades.Enum;

namespace Campeonato.Models
{
    public class ArtilheiroViewModel
    {
        public Categoria Categoria { get; set; }
        public string Escudo { get; set; }
        public string Time { get; set; }
        public string Jogador { get; set; }
        public int Gols { get; set; }
        public string CategoriaClass { get; set; }

    }
}
