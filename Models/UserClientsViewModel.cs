using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UserClientsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome completo.")]
        public string NotCName { get; set; }
        [Required(ErrorMessage = "Digite o login do usuario.")]
        public string NotCLogin { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario.")]
        [EmailAddress(ErrorMessage = "O e-mail informando não é valido.")]
        public string NotCMail { get; set; }
        [Required(ErrorMessage = "Digite o telefone de contato")]
        [Phone(ErrorMessage = "O celular informado está errado")]
        public string NotCPhone { get; set; }
        [Required(ErrorMessage = "Informe o cargo do usuario")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

    }
}
