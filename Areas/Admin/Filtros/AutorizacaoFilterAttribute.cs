using System;
using Campeonato.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Campeonato.Areas.Admin.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var usuario = filterContext.HttpContext.Session.GetString("usuario");


            if (string.IsNullOrWhiteSpace(usuario)) {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new {
                        area = "Admin",
                        controller = "Usuario",
                        action = "Login"}));

                //filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary(
                //        new {
                //            area = "",
                //            controller = "Usuario",
                //            action = "Login"
                //        }));
            }

        }
    }
}
