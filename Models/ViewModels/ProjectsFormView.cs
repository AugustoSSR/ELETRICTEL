namespace ELETRICTEL.Models.ViewModels
{
    public class ProjectsFormView
    {
        public Types Types { get; set; }
        public Company Company { get; set; }
        public Engineers Engineers { get; set; }
        public Status Status { get; set; }
        public RCommercial RCommercial { get; set; }
        public RResponsible RResponsible { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}
