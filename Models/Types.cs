namespace ELETRICTEL.Models
{
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }

        public Types()
        {
        }

        public Types(int id, string name, DateTime createTime, DateTime? changeTime)
        {
            Id = id;
            Name = name;
            CreateTime = createTime;
            ChangeTime = changeTime;
        }
    }
}
