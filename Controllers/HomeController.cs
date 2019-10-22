using Campeonato.Entidades;
using Campeonato.Infra;
using Campeonato.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

            List<Times> lista = _dao.GetTimes();

            return View(lista);

        }

    }

}
