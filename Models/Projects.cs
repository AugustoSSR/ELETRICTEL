using System.ComponentModel;

namespace ELETRICTEL.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        public Types Types { get; set; }
        public int TypesId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string Location { get; set; }

        public string? ProjectKM { get; set; }
        public string? ProjectPostes { get; set; }
        public string? ProjectART { get; set; }
        public string? ProjectStreetART { get; set; }
        public Engineers Engineers { get; set; }
        public int? EnginnersId { get; set; }
        public RCommercial RCommercial { get; set; }
        public int? RCommercialId { get; set; }
        public RResponsible RResponsible { get; set; }
        public int? RResponsibleId { get; set; }

        public string? Protocol { get; set; }
        public DateTime? ProtocolTime { get; set; }
        public DateTime? ApprovedTime { get; set; }


        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }

        public Projects()
        {
        }

        public Projects(int id, string name, DateTime createTime, DateTime? changeTime)
        {
            Id = id;
            Name = name;
            CreateTime = createTime;
            ChangeTime = changeTime;
        }
    }
}
