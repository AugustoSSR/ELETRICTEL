using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELETRICTEL.Models;

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
        public DbSet<ELETRICTEL.Models.Engineers> Engineers { get; set; }
        public DbSet<ELETRICTEL.Models.RCommercial> RCommercial { get; set; }
    }
}
