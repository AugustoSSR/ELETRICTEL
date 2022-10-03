using Microsoft.EntityFrameworkCore;
using ELETRICTEL.Models;
using ELETRICTEL.Models.ViewModels;

namespace ELETRICTEL.Data
{
    public class ELETRICTELContext : DbContext
    {
        public ELETRICTELContext (DbContextOptions<ELETRICTELContext> options)
            : base(options)
        {
        }

        public DbSet<Projects> Projects { get; set; } = default!;
        public DbSet<Types> Types { get; set; } = default!;
        public DbSet<Engineers> Engineers { get; set; }
        public DbSet<RCommercial> RCommercial { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<RResponsible> RResponsible { get; set; }
        public DbSet<UsersViewModel> Users { get; set; }
        public DbSet<UserClients> UsersC { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<ELETRICTEL.Models.ProjectDetails> ProjectDetails { get; set; }
        public DbSet<ELETRICTEL.Models.Files> Files { get; set; }
    }
}
