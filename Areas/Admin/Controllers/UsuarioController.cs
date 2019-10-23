using Campeonato.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Campeonato.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid) {

                if (model.Login == "augusto" && model.Password == "mariana")
                {

                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(model));

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
                
            }

            return View("Login", model);
        }
    }
}