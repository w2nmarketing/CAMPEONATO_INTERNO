using Campeonato.Entidades.Enum;
using Campeonato.Infra;
using Campeonato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campeonato.DAO
{
    public class JogosDao
    {

        private CampeonatoContext contexto;

        public JogosDao(CampeonatoContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Jogos> ListarJogos(Categoria cat)
        {

            var queryJogos = (from jog in contexto.Jogos
                              join fas in contexto.Fases on jog.Fase equals fas.Id
                              where (fas.Categoria == cat)
                              select new
                              {
                                  jog.Id,
                                  jog.Data_Hora,
                                  jog.Time_1,
                                  jog.Time_2,
                                  jog.Goleiro_1,
                                  jog.Goleiro_2

                              });

            var Lista = queryJogos.ToList();

            return Lista;


            // QUERY A SER EXECUTADA
            // --------------------------------------------------------------------------------------------------------------------------------

            //SELECT tbl_jogo.id_Fase, tbl_jogo.Data_Hora, tbl_jogo.id_Time_1, tbl_jogo.Resultado_1, tbl_jogo.id_Time_2, tbl_jogo.Resultado_2,

            //tbl_fase.Nome AS Nome_Fase,

            //time_1.Nome AS Nome_Time_1, time_1.Escudo AS Escudo_Time_1,
            //time_2.Nome AS Nome_Time_2, time_2.Escudo AS Escudo_Time_2

            //FROM tbl_jogo

            //INNER JOIN tbl_fase ON tbl_fase.id = tbl_jogo.id_Fase
            //INNER JOIN tbl_time time_1 ON time_1.id = tbl_jogo.id_Time_1
            //INNER JOIN tbl_time time_2 ON time_2.id = tbl_jogo.id_Time_2

            //WHERE tbl_fase.Categoria = 7

            //ORDER BY tbl_jogo.Data_Hora ASC

            //var Lista = contexto.Jogos.OrderBy(t => t.Data_Hora).ToList();



        }

    }
}
