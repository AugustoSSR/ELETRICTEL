using ELETRICTEL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELETRICTEL.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UsersViewModel usuario)
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            usuario = JsonConvert.DeserializeObject<UsersViewModel>(sessaoUsuario);
            return View(usuario);
        }
    }
}
