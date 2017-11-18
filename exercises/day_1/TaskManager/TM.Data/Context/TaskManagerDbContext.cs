using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TM.Data.Entities;

namespace TM.Data.Context
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public TaskManagerDbContext() 
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database1.mdf; Integrated Security=True;")
        { }
    }
}
