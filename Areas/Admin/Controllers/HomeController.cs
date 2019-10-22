using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {

            return View();

        }

    }
}
