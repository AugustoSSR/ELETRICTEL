
using ELETRICTEL.Models.ViewModels;

namespace ELETRICTEL.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<UsersViewModel> UserViewModel { get; set; } = new List<UsersViewModel>();
        public DateTime CreateTime { get; set; }
        public DateTime? ChangeTime { get; set; }


    }
}
