using Campeonato.Entidades;
using Campeonato.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public List<Jogos> GetJogos()
        {

            return _contexto
                .Jogos
                .Include(j => j.Fase)
                .Include(j => j.Time_1)
                .Include(j => j.Time_2)
                .ToList();
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

            JogoViewModel jogo = new JogoViewModel();

            jogo.Categoria      = jogoEncontrado.Fase.Categoria.ToString();
            jogo.Fase           = jogoEncontrado.Fase.Nome;
            jogo.Data_Hora      = jogoEncontrado.Data_Hora.ToString("dd/MM/yyyy - HH:mm");

            jogo.Escudo_1       = jogoEncontrado.Time_1.Escudo;
            jogo.Time_1         = jogoEncontrado.Time_1.Nome;
            jogo.Resultado_1    = Convert.ToInt32(jogoEncontrado.Resultado_1);

            jogo.Escudo_2       = jogoEncontrado.Time_2.Escudo;
            jogo.Time_2         = jogoEncontrado.Time_2.Nome;
            jogo.Resultado_2    = Convert.ToInt32(jogoEncontrado.Resultado_2);

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

            #region EXEMPLOS

            //SELECT Artista.Nome, Album.Titulo FROM Artista
            //LEFT JOIN Album ON Album.ArtistaId = Artista.ArtistaId;

            //var result = context.Artista
            //.GroupJoin(context.Album, artista => artista.ArtistaId, album => album.ArtistaId,
            //    (artista, album) => new { Artista = artista, Album = album.DefaultIfEmpty() })
            //.SelectMany(a => a.Album, (a, album) => new {
            //    a.Artista.Nome,
            //    album.Titulo
            //}).ToList();


            //JogadorViewModel jogadoresJogo = _contexto
            //    .Jogadores
            //    .GroupJoin(_contexto.GolsDoJogo, j => j.Id, g => g.JogadorId,
            //        (j, g) => new { Jogadores = j, GolsDoJogo => g })
            //    .SelectMany(a => a.Jogadores, (a, j) => new { a.Jogadores.Nome, GolsDoJogo.Gols })
            //    .ToList();

            #endregion

            foreach (var item_1 in jogadoresJogo_1) {
                jogo.Jogadores_1.Add(new JogadorViewModel(item_1.Nome, Convert.ToInt32(item_1.Gols)));
            }

            foreach (var item_2 in jogadoresJogo_2) {
                jogo.Jogadores_2.Add(new JogadorViewModel(item_2.Nome, Convert.ToInt32(item_2.Gols)));
            }

            return jogo;

        }

    }
}
