using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jogos()
        {
            return View();
        }


    }
}
