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

        public DbSet<ELETRICTEL.Models.Projects> Projects { get; set; } = default!;
    }
}
