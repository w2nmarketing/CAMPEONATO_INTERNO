namespace Campeonato.Entidades
{

    public class Jogadores
    {

        public int Id { get; set; }

        public virtual Times Time { get; set; }

        public string Nome { get; set; }

        public Jogadores()
        {

        }

    }
}
