using System.ComponentModel;

namespace ELETRICTEL.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<UsersViewModel> UserViewModel { get; set; } = new List<UsersViewModel>();
        [DisplayName("Create Date")]
        public DateTime CreateTime { get; set; } = DateTime.Now;


    }
}
