using ELETRICTEL.Filters;
using ELETRICTEL.Models;
using ELETRICTEL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ELETRICTEL.Controllers
{
    [PaginaRestritaAdministracao]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usuariosRepositorio;
        public UsersController(IUsersRepository usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }
        public IActionResult Index()
        {
            List<UsersViewModel> usuarios = _usuariosRepositorio.GetUsuario();

            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            UsersViewModel usuario = _usuariosRepositorio.ListarPorID(id);
            return View(usuario);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            UsersViewModel usuario = _usuariosRepositorio.ListarPorID(id);
            return View(usuario);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _usuariosRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = " Usuario apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $" Seu usuario possui algum erro, tente novamente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $" Seu usuario possui algum erro, tente novamente {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Create(UsersViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariosRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = " usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $" Seu usuario possui algum erro, tente novamente {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UsersNotPassViewModel usuarioSemSenha)
        {
            try
            {
                UsersViewModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsersViewModel()
                    {
                        Id = usuarioSemSenha.Id,
                        UsersName = usuarioSemSenha.NotName,
                        UsersLogin = usuarioSemSenha.NotLogin,
                        UsersMail = usuarioSemSenha.NotMail,
                        UsersPhone = usuarioSemSenha.NotPhone,
                        Roles = usuarioSemSenha.Roles
                    };
                    usuario = _usuariosRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = " Usuario alterado com sucesso";
                    return RedirectToAction("Index");

                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $" Seu usuario possui algum erro, tente novamente. Segue o erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
