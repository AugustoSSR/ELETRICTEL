using ELETRICTEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ELETRICTEL.Filters
{
    public class PaginaRestritaAdministracao : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ { "controller" ,"login" }, { "action", "index" } });
            }
            else
            {
                UsersViewModel usuario = JsonConvert.DeserializeObject<UsersViewModel>(sessaoUsuario);
                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (usuario.RolesId != 1) // alterar este metodo depois para outros usuarios terem acesso
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
