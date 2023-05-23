using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ABC.Models;

namespace ABC.Data
{
    public class ABCContext : DbContext
    {
        public ABCContext (DbContextOptions<ABCContext> options)
            : base(options)
        {
        }

        public DbSet<ABC.Models.A> A { get; set; } = default!;

        public DbSet<ABC.Models.B>? B { get; set; }

        public DbSet<ABC.Models.C>? C { get; set; }
    }
}
