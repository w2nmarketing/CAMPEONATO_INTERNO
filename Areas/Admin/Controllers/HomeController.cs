using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();

        }

    }
}
