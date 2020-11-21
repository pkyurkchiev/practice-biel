using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Data.Entities;

namespace TM.Data.DbContexts
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        public AssignmentManagerDbContext(DbContextOptions<AssignmentManagerDbContext> options) 
            : base(options) { }
    }
}
