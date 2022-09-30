using System.ComponentModel;

namespace ELETRICTEL.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Book { get; set; }
        public Projects Projects { get; set; }
        public int? ProjectsId { get; set; }
        public string Box { get; set; }
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [DisplayName("Change Date")]
        public DateTime? ChangeTime { get; set; }

    }
}
