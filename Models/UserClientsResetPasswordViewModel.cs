using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class UserClientsResetPasswordViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite sua senha por favor.")]
        public string PassResetLast { get; set; }
        [Required(ErrorMessage = "Digite a nova senha.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha do usuario deve conter entre 8 e 16 caracteres.")]
        public string PassResetNow { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha do usuario deve conter entre 8 e 16 caracteres.")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não conferem.")]
        public string PassResetConfirmedNow { get; set; }
    }
}
