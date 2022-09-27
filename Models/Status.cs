namespace ELETRICTEL.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }

    }
}
