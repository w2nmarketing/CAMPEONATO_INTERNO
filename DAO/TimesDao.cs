using Campeonato.Infra;
using Campeonato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.DAO
{
    public class TimesDao
    {

        private CampeonatoContext contexto;

        public TimesDao(CampeonatoContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Times> ListarTimes()
        {

            var Lista = contexto.Times.OrderBy(t => t.Categoria).ThenBy(x => x.Id).ToList();

            return Lista;

        }

    }
}
