using Campeonato.Entidades.Enum;

namespace Campeonato.Entidades
{

    public class Times
    {

        public int Id { get; set; }

        public Categoria Categoria { get; set; }
        
        public string Nome { get; set; }

        public string Escudo { get; set; }

        public Times()
        {

        }
    }
}
