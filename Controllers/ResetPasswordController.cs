using ELETRICTEL.Filters;
using ELETRICTEL.Helper;
using ELETRICTEL.Models;
using ELETRICTEL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ELETRICTEL.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ResetPasswordController : Controller
    {
        private readonly IUsersRepository _usuariosRepositorio;
        private readonly IEmail _email;
        private readonly ISessao _sessao;

        public ResetPasswordController(IUsersRepository usuariosRepositorio,
            IEmail email,
            ISessao sessao)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _email = email;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(ResetPasswordViewModel alterarSenhaModel)
        {
            try
            {
                UsersViewModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                UsersViewModel usuarioEmail = _usuariosRepositorio.BuscarPorEmail(usuarioLogado.UsersMail, usuarioLogado.UsersLogin);
                alterarSenhaModel.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {
                    _usuariosRepositorio.AlterarSenha(alterarSenhaModel);

                    string mensagem = $"Ola, sua senha foi alterada com sucesso, caso não tenha sido você, faça agora mesmo a redefinição da sua senha.";

                    bool emailEnviado = _email.Enviar(usuarioEmail.UsersMail, "B Solutions - Alteração de Senha", mensagem);

                    if (emailEnviado)
                    {
                        _usuariosRepositorio.Atualizar(usuarioEmail);
                        TempData["MensagemSucesso"] = "Foi enviado um link para o seu e-mail cadastrado.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Não conseguimos enviar o e-mail, por favor tente novamente.";
                    }


                    TempData["MensagemSucesso"] = "Senha alterada com sucesso.";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! - Não conseguimos alterar sua senha, tente novamente. Erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
