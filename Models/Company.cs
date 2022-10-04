
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class Company
    {
        public int Id { get; set; }

        [DisplayName("Razão Sócial")]
        [Required(ErrorMessage = "Por favor coloque o nome da Razão Sócial")]
        public string Razao { get; set; }

        [DisplayName("Nome Fántasia")]
        [Required(ErrorMessage = "Por favor coloque o nome Fantasia")]
        public string Fantasia { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Por favor coloque o CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Rua")]
        [Required(ErrorMessage = "Por favor coloque o nome da Rua")]
        public string Street { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Por favor coloque o numero da Rua")]
        public string StreetNumber { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Por favor coloque o cep da Rua")]
        public string StreetCep { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Por favor coloque o Estado da empresa")]
        public string StreetState { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Por favor coloque o nome da Cidade")]
        public string StreetCity { get; set; }
        public bool Active { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime CreateTime { get; set; } = DateTime.Now;


        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public ICollection<UserClients> UserClients { get; set; }

    }
}
