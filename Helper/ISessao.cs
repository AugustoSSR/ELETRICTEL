
using ELETRICTEL.Models.ViewModels;

namespace ELETRICTEL.Helper
{
    public interface ISessao
    {
        void criarSessaoUsuario(UsersViewModel usuariosModel);
        void removerSessaoUsuario();
        UsersViewModel BuscarSessaoUsuario();
    }
}
