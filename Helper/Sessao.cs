using ELETRICTEL.Models;
using Newtonsoft.Json;

namespace ELETRICTEL.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsersViewModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsersViewModel>(sessaoUsuario);
        }

        public void criarSessaoUsuario(UsersViewModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void removerSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
