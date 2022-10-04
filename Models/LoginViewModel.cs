using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite o login do usuario.")]
        public string LoginUser { get; set; }
        [Required(ErrorMessage = "Digite sua senha.")]
        //[StringLength(100, MinimumLength = 8, ErrorMessage = "A senha do usuario deve conter entre 8 e 16 caracteres.")]
        public string LoginPassword { get; set; }
    }
}
