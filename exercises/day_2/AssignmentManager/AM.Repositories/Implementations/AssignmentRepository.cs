using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AM.Data.Entities;
using System.Linq;

namespace AM.Repositories.Implementations
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(DbContext context) : base(context) { }

        public override IEnumerable<Assignment> GetAll()
        {
            return this.DbSet.Include(u => u.User).AsEnumerable();
        }
    }
}
