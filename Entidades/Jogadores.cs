using System.Collections.Generic;

namespace Campeonato.Entidades
{

    public class Jogadores
    {

        public int Id { get; set; }

        public int TimeId { get; set; }
        public virtual Times Time { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<GolsDoJogo> GolsdoJogo { get; set; }

        public Jogadores()
        {

        }

    }
}
