using Campeonato.Entidades;
using Campeonato.Entidades.Enum;
using Campeonato.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public Times GetTime(int id_time)
        {
            return _contexto.Times.Find(id_time);
        }

        public List<Jogadores> GetJogadores(int id_jogo)
        {

            Jogos jogoEncontrado = _contexto.Jogos.Find(id_jogo);

            //var listaJogadores = _contexto.Jogadores
            //    .Where(j => j.TimeId == jogoEncontrado.Time_1.Id || j.TimeId == jogoEncontrado.Time_2.Id)
            //    .ToList();

            var listaJogadores = _contexto.Jogadores
                .Include(t => t.Time)
                .Where(j => j.TimeId == jogoEncontrado.Time_1Id || j.TimeId == jogoEncontrado.Time_2Id)
                .ToList();

            return listaJogadores;

        }

        public List<Jogos> GetJogos()
        {

            return _contexto
                .Jogos
                .Include(j => j.Fase)
                .Include(j => j.Time_1)
                .Include(j => j.Time_2)
                .ToList();
        }

        public void AddGol(GolsDoJogo novoGol)
        {

            _contexto.GolsDoJogo.Add(novoGol);
            _contexto.SaveChanges();

            int Resultado_1;
            int Resultado_2;

            Jogadores jogadorEncontrado = _contexto.Jogadores.Find(novoGol.JogadorId);

            Jogos jogoEncontrado = _contexto.Jogos.Find(novoGol.JogoId);

            if (jogoEncontrado.Resultado_1 == null) {
                Resultado_1 = 0;
            } else {
                Resultado_1 = Convert.ToInt32(jogoEncontrado.Resultado_1);
            }

            if (jogoEncontrado.Resultado_2 == null) {
                Resultado_2 = 0;
            } else {
                Resultado_2 = Convert.ToInt32(jogoEncontrado.Resultado_2);
            }

            if (jogadorEncontrado.TimeId == jogoEncontrado.Time_1Id) {
                Resultado_1 += Convert.ToInt32(novoGol.Gols);

            }else if (jogadorEncontrado.TimeId == jogoEncontrado.Time_2Id) {
                Resultado_2 += Convert.ToInt32(novoGol.Gols);

            }

            jogoEncontrado.Resultado_1 = Resultado_1;
            jogoEncontrado.Resultado_2 = Resultado_2;

            _contexto.Attach(jogoEncontrado);
            _contexto.SaveChanges();

        }

        public JogoViewModel GetJogo(int jogo_id)
        {

            Jogos jogoEncontrado = _contexto
                .Jogos
                .Include(j => j.Fase)
                .Include(j => j.Time_1)
                .Include(j => j.Time_2)
                .Where(j => j.Id == jogo_id)
                .FirstOrDefault();


            var jogadoresJogo_1 = _contexto
                .Jogadores
                .GroupJoin(_contexto.GolsDoJogo, j => j.Id, g => g.JogadorId,
                    (j, g) => new { Jogadores = j, GolsDoJogo = g.DefaultIfEmpty() })
                .SelectMany(a => a.GolsDoJogo, (a, j) => new { j.JogoId, a.Jogadores.TimeId, a.Jogadores.Nome, j.Gols })
                .Where(p => p.JogoId == jogo_id && p.TimeId == jogoEncontrado.Time_1.Id)
                .ToList();

            var jogadoresJogo_2 = _contexto
                .Jogadores
                .GroupJoin(_contexto.GolsDoJogo, j => j.Id, g => g.JogadorId,
                    (j, g) => new { Jogadores = j, GolsDoJogo = g.DefaultIfEmpty() })
                .SelectMany(a => a.GolsDoJogo, (a, j) => new { j.JogoId, a.Jogadores.TimeId, a.Jogadores.Nome, j.Gols })
                .Where(p => p.JogoId == jogo_id && p.TimeId == jogoEncontrado.Time_2.Id)
                .ToList();


            JogoViewModel jogo = new JogoViewModel {
                Categoria = jogoEncontrado.Fase.Categoria.ToString(),
                Fase = jogoEncontrado.Fase.Nome,
                Data_Hora = jogoEncontrado.Data_Hora.ToString("dd/MM/yyyy - HH:mm"),

                Escudo_1 = jogoEncontrado.Time_1.Escudo,
                Time_1 = jogoEncontrado.Time_1.Nome,
                Resultado_1 = Convert.ToInt32(jogoEncontrado.Resultado_1),

                Escudo_2 = jogoEncontrado.Time_2.Escudo,
                Time_2 = jogoEncontrado.Time_2.Nome,
                Resultado_2 = Convert.ToInt32(jogoEncontrado.Resultado_2)
            };

            foreach (var item_1 in jogadoresJogo_1) {
                jogo.Jogadores_1.Add(new JogadorViewModel(item_1.Nome, Convert.ToInt32(item_1.Gols)));
            }

            foreach (var item_2 in jogadoresJogo_2) {
                jogo.Jogadores_2.Add(new JogadorViewModel(item_2.Nome, Convert.ToInt32(item_2.Gols)));
            }

            return jogo;

        }

        public List<Classificacao> GetClassificacao(Categoria categoria)
        {

            string filtroCat = "";

                switch (categoria) {
                    case Categoria.Sub7:
                        filtroCat = " tbl_time.Categoria = 7";
                        break;
                    case Categoria.Sub9:
                        filtroCat = " tbl_time.Categoria = 9";
                        break;
                    case Categoria.Sub12:
                        filtroCat = " tbl_time.Categoria = 12";
                        break;
                    case Categoria.Sub15:
                        filtroCat = " tbl_time.Categoria = 15";
                        break;
                    default:
                        filtroCat = " tbl_time.Categoria = 7";
                        break;
                }

            var listClassificacao = _contexto.Classificacao.FromSql("SELECT view_pontos_jogos.Id_Time, " +
                "COUNT(view_pontos_jogos.Id_Time) AS Jogos, SUM(view_pontos_jogos.Pontos) AS Total_Pontos, " +
                "SUM(view_pontos_jogos.Vitorias) AS Total_Vitorias, " +
                "SUM(view_pontos_jogos.Empates) AS Total_Empates, Sum(view_pontos_jogos.Derrotas) AS Total_Derrotas, " +
                "SUM(view_pontos_jogos.Saldo_Gols) AS Saldo_Gols, SUM(view_pontos_jogos.Gols_Marcados) AS Gols_Marcados, " +
                "SUM(view_pontos_jogos.Gols_Sofridos) AS Gols_Sofridos, tbl_time.Nome, tbl_time.Escudo, tbl_time.Categoria " +
                "FROM view_pontos_jogos INNER JOIN tbl_time ON tbl_time.Id = view_pontos_jogos.Id_Time " +
                "WHERE " + filtroCat + " " + 
                "GROUP BY view_pontos_jogos.Id_Time " +
                "ORDER BY 3 DESC, 4 DESC, 7 DESC, 8 DESC").ToList();

            return listClassificacao;

        }

        public List<ArtilheiroViewModel> GetArtilheiros(Categoria categoria)
        {
            List<ArtilheiroViewModel> lista = new List<ArtilheiroViewModel>();

            var items = _contexto
                .GolsDoJogo
                .Where(c => c.Jogo.Fase.Categoria == categoria)
                .GroupBy(x => new { x.JogadorId, x.Jogo.Fase.Categoria })
                .Select(g => new { g.Key.JogadorId, g.Key.Categoria, Gols = g.Sum(s => s.Gols) });

            foreach (var item in items) {

                var jogador = _contexto.Jogadores.Include(j => j.Time).FirstOrDefault(j => j.Id == item.JogadorId);

                string nomeClass = "";

                switch (item.Categoria) {
                    case Categoria.Sub7:
                        nomeClass = "success";
                        break;
                    case Categoria.Sub9:
                        nomeClass = "info";
                        break;
                    case Categoria.Sub12:
                        nomeClass = "warning";
                        break;
                    case Categoria.Sub15:
                        nomeClass = "dark";
                        break;
                    default:
                        break;
                }

                lista.Add(new ArtilheiroViewModel() {
                    Jogador = jogador.Nome,
                    Gols = Convert.ToInt32(item.Gols),
                    Categoria = item.Categoria,
                    CategoriaClass = nomeClass,
                    Time = jogador.Time.Nome.ToString(),
                    Escudo = jogador.Time.Escudo.ToString()
                });

            }

            lista = lista.OrderByDescending(j => j.Gols).ToList();

            return lista;
        }


        //public List<ArtilheiroViewModel> GetArtilheiros(Categoria categoria)
        //{

        //    List<ArtilheiroViewModel> lista = new List<ArtilheiroViewModel>();

        //    var listaArtilheiros = _contexto
        //        .GolsDoJogo
        //        .Include(g => g.Jogador)
        //        .Include(g => g.Jogo)
        //        .OrderByDescending(o => o.Gols)
        //        .ThenBy(j => j.Jogador.Nome)
        //        .Select(c => new { Jogador = c.Jogador.Nome, c.Gols, c.Jogo.Fase.Categoria, c.Jogador.Time })
        //        .ToList();



        //    foreach (var jogador in listaArtilheiros) {

        //        string nomeClass = "";

        //        switch (jogador.Categoria) {
        //            case Categoria.Sub7:
        //                nomeClass = "success";
        //                break;
        //            case Categoria.Sub9:
        //                nomeClass = "info";
        //                break;
        //            case Categoria.Sub12:
        //                nomeClass = "warning";
        //                break;
        //            case Categoria.Sub15:
        //                nomeClass = "dark";
        //                break;
        //            default:
        //                break;
        //        }

        //        lista.Add(new ArtilheiroViewModel() {
        //            Jogador = jogador.Jogador,
        //            Gols = Convert.ToInt32(jogador.Gols),
        //            Categoria = jogador.Categoria,
        //            CategoriaClass = nomeClass,
        //            Time = jogador.Time.Nome.ToString(),
        //            Escudo = jogador.Time.Escudo.ToString()
        //        });

        //    }

        //    return lista;

        //}

        //public List<ArtilheiroViewModel> GetArtilheiros(int categoria)
        //{

        //    //string filtroCat = "";

        //    //switch (categoria) {
        //    //    case 9:
        //    //        filtroCat = " tbl_time.Categoria = 9";
        //    //        break;
        //    //    case 12:
        //    //        filtroCat = " tbl_time.Categoria = 12";
        //    //        break;
        //    //    case 15:
        //    //        filtroCat = " tbl_time.Categoria = 15";
        //    //        break;
        //    //    default:
        //    //        filtroCat = " tbl_time.Categoria = 7";
        //    //        break;
        //    //}

        //    //var listArtilharia = _contexto.Database.ExecuteSqlCommand("SELECT " +
        //    //    "tbl_time.Categoria, " +
        //    //    "tbl_time.Escudo, " +
        //    //    "tbl_time.Nome AS Time, " +
        //    //    "rel_time_jogador.Nome AS Jogador, " +
        //    //    "SUM(rel_jogo_gols.Gols) AS Gols " +
        //    //    "FROM rel_jogo_gols " +
        //    //    "INNER JOIN rel_time_jogador ON rel_time_jogador.Id = rel_jogo_gols.JogadorId " +
        //    //    "INNER JOIN  tbl_time ON tbl_time.Id = rel_time_jogador.TimeId " +
        //    //    "WHERE tbl_time.Categoria = @categoria " +
        //    //    "GROUP BY rel_jogo_gols.JogadorId " +
        //    //    "ORDER BY 5 DESC, 4 ASC;", new SqlParameter("@categoria", categoria)).FirstOrDefault();


        //    //List<ArtilheiroViewModel> lista = new List<ArtilheiroViewModel>();

        //    ////var listaArtilheiros = _contexto
        //    ////    .GolsDoJogo
        //    ////    .Include(g => g.Jogador)
        //    ////    .Include(g => g.Jogo)
        //    ////    .Where(c => c.Jogo.Fase.Categoria == categoria)
        //    ////    .OrderByDescending(o => o.Gols)
        //    ////    .ThenBy(j => j.Jogador.Nome)
        //    ////    .Select(c => new { Jogador = c.Jogador.Nome, c.Gols, c.Jogo.Fase.Categoria, c.Jogador.Time })
        //    ////    .ToList();

        //    //foreach (var jogador in listArtilharia) {
        //    //}

        //    //    string nomeClass = "";

        //    //    //Categoria cat_id = (Categoria)Enum.Parse(typeof(Categoria), jogador.Categoria);



        //    //    //switch () {
        //    //    //    case Categoria.Sub7:
        //    //    //        nomeClass = "success";
        //    //    //        break;
        //    //    //    case Categoria.Sub9:
        //    //    //        nomeClass = "info";
        //    //    //        break;
        //    //    //    case Categoria.Sub12:
        //    //    //        nomeClass = "warning";
        //    //    //        break;
        //    //    //    case Categoria.Sub15:
        //    //    //        nomeClass = "dark";
        //    //    //        break;
        //    //    //    default:
        //    //    //        break;
        //    //    //}

        //    //    lista.Add(new ArtilheiroViewModel() {
        //    //        //Jogador = jogador.Jogador,
        //    //        //Gols = Convert.ToInt32(jogador.Gols),
        //    //        //Categoria = jogador.Categoria,
        //    //        CategoriaClass = nomeClass,
        //    //        Time = jogador.Time.Nome.ToString(),
        //    //        Escudo = jogador.Time.Escudo.ToString()
        //    //    });

        //    //}

        //    //return listArtilharia;

        //}

    }
}
