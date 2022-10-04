using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UsersNotPassViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome completo.")]
        public string NotName { get; set; }
        [Required(ErrorMessage = "Digite o login do usuario.")]
        public string NotLogin { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario.")]
        [EmailAddress(ErrorMessage = "O e-mail informando não é valido.")]
        public string NotMail { get; set; }
        [Required(ErrorMessage = "Digite o telefone de contato")]
        [Phone(ErrorMessage = "O celular informado está errado")]
        public string NotPhone { get; set; }
        [Required(ErrorMessage = "Informe o cargo do usuario")]
        public Roles Roles { get; set; }
        public int? RolesId { get; set; }

    }
}
