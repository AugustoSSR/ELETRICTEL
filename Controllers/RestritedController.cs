using ELETRICTEL.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ELETRICTEL.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
