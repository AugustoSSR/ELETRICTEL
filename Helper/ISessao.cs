
using ELETRICTEL.Models;

namespace ELETRICTEL.Helper
{
    public interface ISessao
    {
        void criarSessaoUsuario(UsersViewModel usuariosModel);
        void removerSessaoUsuario();
        UsersViewModel BuscarSessaoUsuario();
    }
}
