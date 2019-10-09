using Campeonato.Entidades;
using Campeonato.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.Models
{
    public class WebDao
    {

        private readonly CampeonatoContext _contexto;

        public WebDao(CampeonatoContext contexto)
        {
            _contexto = contexto;

        }

        public List<Times> GetTimes()
        {           
            return _contexto.Times.OrderBy(x => x.Nome).ToList();

        }

        public List<Jogos> GetJogos()
        {
            return _contexto
                .Jogos
                .Include(j => j.Goleiro_1)
                .Include(j => j.Goleiro_2)
                .Include(j => j.Time_1)
                .Include(j => j.Time_2)
                .ToList();
        }


    }
}
