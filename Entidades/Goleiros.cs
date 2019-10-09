using Campeonato.Entidades.Enum;
using System.Collections.Generic;

namespace Campeonato.Entidades
{

    public class Goleiros
    {

        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Jogos> Jogos1 { get; set; }
        public virtual ICollection<Jogos> Jogos2 { get; set; }

        public Goleiros()
        {
        }

    }
}
