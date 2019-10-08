using Campeonato.Entidades.Enum;

namespace Campeonato.Entidades
{

    public class Goleiros
    {

        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public Goleiros()
        {
        }

    }
}
