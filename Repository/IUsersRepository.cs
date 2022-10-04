using ELETRICTEL.Models;

namespace ELETRICTEL.Repository
{
    public interface IUsersRepository
    {
        UsersViewModel BuscarPorEmail(string email, string login);
        UsersViewModel BuscarPorLogin(string login);
        List<UsersViewModel> GetUsuario();
        UsersViewModel ListarPorID(int id);
        UsersViewModel Adicionar(UsersViewModel usuario);
        UsersViewModel Atualizar(UsersViewModel usuario);
        UsersViewModel AlterarSenha(ResetPasswordViewModel alterarSenhaModel);


        bool Apagar(int id);

    }
}
