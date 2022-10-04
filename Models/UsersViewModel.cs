using ELETRICTEL.Helper;
using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome completo.")]
        public string UsersName { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O nome de usuario deve conter entre 5 e 10 caracteres.")]
        public string UsersLogin { get; set; }

        [Required(ErrorMessage = "Digite sua senha por favor.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha do usuario deve conter entre 8 e 16 caracteres.")]
        public string UsersPassword { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuario.")]
        [EmailAddress(ErrorMessage = "O e-mail informando não é valido.")]
        public string UsersMail { get; set; }

        [Required(ErrorMessage = "Digite o telefone de contato")]
        [Phone(ErrorMessage = "O celular informado está errado")]
        public string UsersPhone { get; set; }

        [Required(ErrorMessage = "Informe o cargo do usuario")]
        public Roles Roles { get; set; }
        public int? RolesId { get; set; }
        [Required(ErrorMessage = "Informe o status do usuario")]
        public bool Actived { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }

        public bool SenhaValida(string senha)
        {
            return UsersPassword == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            UsersPassword = UsersPassword.GerarHash();
        }
        public void SetNovaSenha(string novaSenha)
        {
            UsersPassword = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            // gerar nova senha com hash sha1.
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            UsersPassword = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
