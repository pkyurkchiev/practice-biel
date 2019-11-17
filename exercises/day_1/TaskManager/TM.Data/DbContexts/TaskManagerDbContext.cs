using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Data.Entities;

namespace TM.Data.DbContexts
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }
    }
}
