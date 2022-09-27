namespace ELETRICTEL.Models
{
    public class RResponsible
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }
    }
}
