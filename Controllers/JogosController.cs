﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campeonato.Entidades;
using Campeonato.Entidades.Enum;
using Campeonato.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class JogosController : Controller
    {

        private readonly WebDao _dao;

        public JogosController(WebDao dao)
        {
            this._dao = dao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/jogos/categoria/{categoria}")]
        [HttpGet]
        public IActionResult Categoria(Categoria categoria)
        {

            ViewBag.Categoria = categoria;

            ViewBag.Listar_Jogos = _dao.GetJogos()
                .Where(p => p.Fase.Categoria == categoria)
                .OrderByDescending(p => p.FaseId)
                .ThenBy(j => j.Data_Hora)
                .ToList();

            return View("ListaCategoria");

        }

        [HttpGet("/jogos/time/{time_id}")]
        public IActionResult Time(int time_id)
        {

            ViewBag.Time = _dao.GetTime(time_id);

            ViewBag.Listar_Jogos = _dao.GetJogos()
                .Where((p => p.Time_1.Id == time_id || p.Time_2.Id == time_id))
                .OrderByDescending(p => p.FaseId)
                .ThenBy(j => j.Data_Hora)
                .ToList();

            return View("ListaTime");
        }

        [HttpGet("/jogo/detalhes/{jogo_id}")]
        public IActionResult Jogo(int jogo_id)
        {

            JogoViewModel jogo = _dao.GetJogo(jogo_id);

            return View("Detalhes", jogo);
        }

    }
}