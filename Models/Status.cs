using System.ComponentModel;

namespace ELETRICTEL.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; } = DateTime.Now;


        public ICollection<Projects> Projects { get; set; } = new List<Projects>();

    }
}
