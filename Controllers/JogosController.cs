using Campeonato.Entidades;
using Campeonato.Entidades.Enum;
using Campeonato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Campeonato.Controllers
{
    public class JogosController : Controller
    {

        [HttpGet("/jogos/categoria/{categoria}")]
        public IActionResult Categoria(Categoria categoria)
        {

            DALJogos dal = new DALJogos();

            ViewBag.Categoria = categoria;
            ViewBag.Listar_Jogos = dal.GetJogos().Where(p => p.Fase.Categoria == categoria);

            return View("ListaCategoria");
        }

        [HttpGet("/jogos/time/{time_id}")]
        public IActionResult Time(int time_id)
        {

            DALJogos dal = new DALJogos();
            DALTimes dal2 = new DALTimes();

            ViewBag.Time = dal2.GetTime(time_id);

            ViewBag.Listar_Jogos = dal.GetJogos().Where(p => p.Time_1.Id == time_id || p.Time_2.Id == time_id).ToList();

            return View("ListaTime");
        }


    }
}