using Campeonato.Entidades;
using Campeonato.Infra;
using System;
using System.Collections.Generic;
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

            return _contexto.Times.ToList();

        }


    }
}
