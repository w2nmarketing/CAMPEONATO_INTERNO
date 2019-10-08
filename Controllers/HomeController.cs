using Campeonato.Infra;
using Campeonato.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class HomeController : Controller
    {

        private readonly WebDao _dao;
        
        public HomeController(WebDao dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {

            ViewBag.Listar_Times = _dao.GetTimes();

            return View();

        }

    }

}
