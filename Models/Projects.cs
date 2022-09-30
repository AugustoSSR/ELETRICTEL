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

        public string? ProjectKM { get; set; }
        public string? ProjectPostes { get; set; }
        public string? ProjectART { get; set; }
        public string? ProjectStreetART { get; set; }
        public Engineers Engineers { get; set; }
        public int? EngineersId { get; set; }
        public RCommercial RCommercial { get; set; }
        public int? RCommercialId { get; set; }
        public RResponsible RResponsible { get; set; }
        public int? RResponsibleId { get; set; }

        [DisplayName("N° Protocolo")]
        public string? Protocol { get; set; }
        [DisplayName("Data de Protocolo")]
        public DateTime? ProtocolTime { get; set; }
        [DisplayName("Data de Aprovação")]
        public DateTime? ApprovedTime { get; set; }


        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; }
        [DisplayName("Change Date")]
        public DateTime? ChangeTime { get; set; }

        public Projects()
        {
        }

    }
}
