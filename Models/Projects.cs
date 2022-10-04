
namespace ELETRICTEL.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Types Types { get; set; }
        public int TypesId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string Location { get; set; }
        public int ProjectDetailsId { get; set; }
        public virtual List<ProjectDetails> ProjectDetails { get; set; } = new List<ProjectDetails>();
        public DateTime? CreateTime { get; set; } = DateTime.Now;

    }
}
