using ELETRICTEL.Data;
using ELETRICTEL.Models;
using ELETRICTEL.Models.ViewModels;

namespace ELETRICTEL.Repository
{
    public class UsersClientsRepository : IUsersClientsRepository
    {
        private readonly ELETRICTELContext _bancoContext;
        public UsersClientsRepository(ELETRICTELContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UserClients BuscarPorLogin(string login)
        {
            return _bancoContext.UsersC.FirstOrDefault(x => x.cLogin.ToUpper() == login.ToUpper());
        }
        public UserClients BuscarPorEmail(string email, string login)
        {
            return _bancoContext.UsersC.FirstOrDefault(x => x.cMail.ToUpper() == email.ToUpper() && x.cLogin.ToUpper() == login.ToUpper());
        }
        public UserClients ListarPorID(int id)
        {
            return _bancoContext.UsersC.FirstOrDefault(x => x.Id == id);
        }
        public List<UserClients> GetUsuario()
        {
            // listagem de projetos
            return _bancoContext.UsersC.ToList();
        }
        public UserClients Adicionar(UserClients usuario)
        {
            // Inserção do banco de dados.
            usuario.CreateTime = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoContext.UsersC.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UserClients Atualizar(UserClients usuario)
        {
            UserClients usuarioDB = ListarPorID(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do projeto.");
            usuarioDB.cName = usuario.cName;
            usuarioDB.cLogin = usuario.cLogin;
            usuarioDB.cMail = usuario.cMail;
            usuarioDB.cPhone = usuario.cPhone;
            usuarioDB.Company = usuario.Company;
            usuarioDB.ChangeTime = DateTime.Now;

            _bancoContext.UsersC.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public UserClients AlterarSenha(UserClientsResetPasswordViewModel alterarSenhaModel)
        {
            UserClients usuarioDB = ListarPorID(alterarSenhaModel.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado.");
            if (!usuarioDB.SenhaValida(alterarSenhaModel.PassResetLast)) throw new Exception("Senha atual não confere.");
            if (usuarioDB.SenhaValida(alterarSenhaModel.PassResetNow)) throw new Exception("Nova senha deve ser diferenda da senha atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.PassResetNow);
            usuarioDB.ChangeTime = DateTime.Now;

            _bancoContext.UsersC.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UserClients usuarioDB = ListarPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na deleção do projeto.");

            _bancoContext.UsersC.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
