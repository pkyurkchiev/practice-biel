using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AM.Repositories.Implementations
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(DbContext context) : base(context) { }

        public override IEnumerable<Assignment> GetAll()
        {
            return this.Context.Set<Assignment>().Include("User").AsEnumerable();
        }
    }
}
