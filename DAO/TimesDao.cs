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

        public List<Times> ListarTimes()
        {

            using (var contexto = new CampeonatoContext())
            {

                return contexto.Times.ToList();

            };

        }

    }
}
