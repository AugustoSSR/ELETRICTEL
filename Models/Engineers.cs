namespace ELETRICTEL.Models
{
    public class Engineers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CREA { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public ICollection<ProjectDetails> ProjectDetails { get; set; } = new List<ProjectDetails>();
    }
}
