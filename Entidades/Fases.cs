using Campeonato.Entidades.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Campeonato.Entidades
{

    public class Fases
    {

        public int Id { get; set; }

        public Categoria Categoria { get; set; }

        public string Nome { get; set; }

        public Fases()
        {
        }

    }
}
