using Campeonato.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Controllers
{
    public class HomeController : Controller
    {

        
        public HomeController()
        {
        }

        public IActionResult Index()
        {

            DALTimes dal = new DALTimes();

            ViewBag.Listar_Times = dal.GetTimes();

            return View();

        }

    }

}
