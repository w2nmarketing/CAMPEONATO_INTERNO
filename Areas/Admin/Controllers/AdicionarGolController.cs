using Campeonato.Areas.Admin.Filtros;
using Campeonato.Entidades;
using Campeonato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AutorizacaoFilter]
    public class AdicionarGolController : Controller
    {


        private readonly WebDao _dao;

        public AdicionarGolController(WebDao dao)
        {

            this._dao = dao;
        }

        [Route("/admin/adicionargol")]
        [HttpGet]
        public IActionResult Index()
        {

            List<Jogos> listaJogos = _dao.GetJogos()
                .Where(p => p.Resultado_1 == null && p.Resultado_2 == null)
                .OrderBy(j => j.Data_Hora)
                .ToList();

            return View(listaJogos);

        }

        [Route("/admin/adicionargol/{id_jogo}")]
        [HttpGet]
        public IActionResult Cadastro(int id_jogo)
        {

            JogoViewModel Jogo = _dao.GetJogo(id_jogo);

            ViewBag.JogoId = id_jogo;
            ViewBag.Listar_Jogadores = _dao.GetJogadores(id_jogo);

            return View(Jogo);

        }

        public IActionResult Salvar(GolsDoJogo novoGol)
        {

            _dao.AddGol(novoGol);

            return Redirect("/admin/adicionargol/" + novoGol.JogoId);

        }

    }
}
