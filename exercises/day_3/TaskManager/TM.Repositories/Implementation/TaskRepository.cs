using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Repositories.Interface;

namespace TM.Repositories.Implementation
{
    public class TaskRepository : Repository<TM.Data.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DbContext context)
            : base(context) { }
    }
}
