using Campeonato.Areas.Admin.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AutorizacaoFilter]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Sair()
        {

            HttpContext.Session.Clear();

            return Redirect("/admin");

        }
    }
}
