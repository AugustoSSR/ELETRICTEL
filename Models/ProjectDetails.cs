using System.ComponentModel;

namespace ELETRICTEL.Models
{
    public class ProjectDetails
    {
        public int Id { get; set; }
        public Projects Projects { get; set; }
        public int ProjectsId { get; set; }
        public string ProjectKM { get; set; }
        public string ProjectPostes { get; set; }
        public string ProjectART { get; set; }
        public string ProjectStreetART { get; set; }
        public Engineers Engineers { get; set; }
        public int EngineersId { get; set; }
        public RCommercial RCommercial { get; set; }
        public int RCommercialId { get; set; }
        public RResponsible RResponsible { get; set; }
        public int RResponsibleId { get; set; }
        public string Protocol { get; set; }
        public DateTime? ProtocolTime { get; set; }
        public DateTime? ApprovedTime { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
