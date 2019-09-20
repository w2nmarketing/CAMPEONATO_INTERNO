using Campeonato.DAO;
using Campeonato.Entidades.Enum;
using Campeonato.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class HomeController : Controller
    {

        private CampeonatoContext contexto;
        private TimesDao dao;
        private JogosDao dao2;

        public HomeController()
        {
            contexto = new CampeonatoContext();
            dao = new TimesDao(contexto);
            dao2 = new JogosDao(contexto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contexto.Dispose();
            }
            base.Dispose(disposing);

        }

        public IActionResult Index()
        {

            ViewBag.Lista_Times = dao.ListarTimes();

            return View();

        }

        [HttpGet("/jogos/{cat}")]
        public IActionResult ListarJogosCategoria(Categoria cat)
        {

            ViewBag.Categoria = cat;
            ViewBag.Lista_Jogos = dao2.ListarJogos(cat);

            return View("ListarJogos");
        }


    }
}
