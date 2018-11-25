using System.Data.Entity;
using TM.Data.Entities;

namespace TM.Data.DBContexts
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TaskManagerDbContext() 
            : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\fmi\source\repos\TaskManager\TaskManagerDB.mdf;") { }
    }
}
