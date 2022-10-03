
using ELETRICTEL.Models;

namespace ELETRICTEL.Repository
{
    public interface IUsersClientsRepository
    {
        UserClients BuscarPorEmail(string email, string login);
        UserClients BuscarPorLogin(string login);
        List<UserClients> GetUsuario();
        UserClients ListarPorID(int id);
        UserClients Adicionar(UserClients usuario);
        UserClients Atualizar(UserClients usuario);
        UserClients AlterarSenha(UserClientsResetPasswordViewModel alterarSenhaModel);


        bool Apagar(int id);
    }
}
