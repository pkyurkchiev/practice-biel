using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AM.Data.Entities;

namespace AM.Data.DbContexts
{
    public class AssignmentManagerDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        public AssignmentManagerDbContext(DbContextOptions<AssignmentManagerDbContext> options) 
            : base(options) { }
    }
}
