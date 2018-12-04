using System.Data.Entity;
using TM.Data.Entities;

namespace TM.Repositories.Implementations
{
    public class TaskRepository : Repository<Task>
    {
        public TaskRepository(DbContext context) : base(context) { }
    }
}
