using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Por favor, coloque o nome do projeto.")]
        public string Name { get; set; }
        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Por favor, selecione o tipo do projeto.")]
        public Types Types { get; set; }
        public int TypesId { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Por favor, selecione o status do projeto.")]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        [DisplayName("Empresa")]
        [Required(ErrorMessage = "Por favor, selecione a empresa do projeto.")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [DisplayName("Localidade")]
        [Required(ErrorMessage = "Por favor, coloque o nome da localidade do projeto.")]
        public string Location { get; set; }
        [DisplayName("Create Date")]
        public DateTime? CreateTime { get; set; } = DateTime.Now;


        public ICollection<ProjectDetails> ProjectDetails { get; set; } = new List<ProjectDetails>();

    }
}
