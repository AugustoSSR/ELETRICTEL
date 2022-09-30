using ELETRICTEL.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ELETRICTEL.Controllers.ClientsControllers
{
    [PaginaParaUsuarioLogado]
    public class CRestritedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
