using ELETRICTEL.Data;
using ELETRICTEL.Models.ViewModels;

namespace ELETRICTEL.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ELETRICTELContext _bancoContext;
        public UsersRepository(ELETRICTELContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsersViewModel BuscarPorLogin(string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.UsersLogin.ToUpper() == login.ToUpper());
        }
        public UsersViewModel BuscarPorEmail(string email, string login)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.UsersMail.ToUpper() == email.ToUpper() && x.UsersLogin.ToUpper() == login.ToUpper());
        }
        public UsersViewModel ListarPorID(int id)
        {
            return _bancoContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public List<UsersViewModel> GetUsuario()
        {
            // listagem de projetos
            return _bancoContext.Users.ToList();
        }
        public UsersViewModel Adicionar(UsersViewModel usuario)
        {
            // Inserção do banco de dados.
            usuario.CreateTime = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.Users.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsersViewModel Atualizar(UsersViewModel usuario)
        {
            UsersViewModel usuarioDB = ListarPorID(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do projeto.");
            usuarioDB.UsersName = usuario.UsersName;
            usuarioDB.UsersLogin = usuario.UsersLogin;
            usuarioDB.UsersMail = usuario.UsersMail;
            usuarioDB.UsersPhone = usuario.UsersPhone;
            usuarioDB.Roles = usuario.Roles;
            usuarioDB.ChangeTime = DateTime.Now;

            _bancoContext.Users.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public UsersViewModel AlterarSenha(ResetPasswordViewModel alterarSenhaModel)
        {
            UsersViewModel usuarioDB = ListarPorID(alterarSenhaModel.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado.");
            if (!usuarioDB.SenhaValida(alterarSenhaModel.PassResetLast)) throw new Exception("Senha atual não confere.");
            if (usuarioDB.SenhaValida(alterarSenhaModel.PassResetNow)) throw new Exception("Nova senha deve ser diferenda da senha atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.PassResetNow);
            usuarioDB.ChangeTime = DateTime.Now;

            _bancoContext.Users.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsersViewModel usuarioDB = ListarPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do projeto.");

            _bancoContext.Users.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

    }
}
