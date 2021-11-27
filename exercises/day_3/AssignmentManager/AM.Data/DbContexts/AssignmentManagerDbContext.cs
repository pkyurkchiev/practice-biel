using AM.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.DbContexts
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public AssignmentManagerDbContext(DbContextOptions<AssignmentManagerDbContext> options) : base(options)
        { }
    }
}
