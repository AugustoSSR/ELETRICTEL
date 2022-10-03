using Microsoft.AspNetCore.Components;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELETRICTEL.Models
{
    public class Types
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Por favor, coloque o nome do tipo do projeto.")]
        public string Name { get; set; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
