using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TM.Data.Entities;
using TM.Repositories.Interfaces;

namespace TM.Repositories.Implementations
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
