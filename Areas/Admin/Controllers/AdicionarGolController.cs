using Campeonato.Entidades;
using Campeonato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdicionarGolController : Controller
    {


        private readonly WebDao _dao;

        public AdicionarGolController(WebDao dao)
        {

            this._dao = dao;
        }

        [Route("/admin/adicionargol/{id_jogo}")]
        [HttpGet]
        public IActionResult Index(int id_jogo)
        {

            ViewBag.JogoId = id_jogo;
            ViewBag.Listar_Jogadores = _dao.GetJogadores(id_jogo);

            return View();

        }

        public IActionResult Salvar(GolsDoJogo novoGol)
        {

            _dao.AddGol(novoGol);

            return Redirect("/admin/adicionargol/" + novoGol.JogoId);

        }

    }
}
