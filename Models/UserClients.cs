using ELETRICTEL.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UserClients
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome completo.")]
        public string cName { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O nome de usuario deve conter entre 5 e 10 caracteres.")]
        public string cLogin { get; set; }

        [Required(ErrorMessage = "Digite sua senha por favor.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha do usuario deve conter entre 8 e 16 caracteres.")]
        public string cPassword { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuario.")]
        [EmailAddress(ErrorMessage = "O e-mail informando não é valido.")]
        public string cMail { get; set; }

        [Required(ErrorMessage = "Digite o telefone de contato")]
        [Phone(ErrorMessage = "O celular informado está errado")]
        public string cPhone { get; set; }

        [Required(ErrorMessage = "Informe o cargo do usuario")]
        public Company Company { get; set; }
        public int CompanyId { get; set; } = 0;
        [Required(ErrorMessage = "Informe o status do usuario")]
        public bool Actived { get; set; } = false;
        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; }
        [DisplayName("Change Date")]
        public DateTime? ChangeTime { get; set; }

        public bool SenhaValida(string senha)
        {
            return cPassword == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            cPassword = cPassword.GerarHash();
        }
        public void SetNovaSenha(string novaSenha)
        {
            cPassword = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            // gerar nova senha com hash sha1.
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            cPassword = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
