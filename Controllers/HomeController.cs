using Campeonato.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            TimesDao registros = new TimesDao();

            return View(registros.ListarTimes());

        }

        public IActionResult Jogos()
        {

                       
            return View();
        }


    }
}
