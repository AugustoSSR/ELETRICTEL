using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UserClientsResetPasswordMailViewModel
    {
        [Required(ErrorMessage = "Por favor, digite o login.")]
        public string ResetLogin { get; set; }
        [Required(ErrorMessage = "Por favor digite o seu e-mail.")]
        [EmailAddress(ErrorMessage = "Por favor digite um e-mail válido.")]
        public string ResetMail { get; set; }
    }
}
