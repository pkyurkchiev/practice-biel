using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AM.Repositories.Implementations
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(DbContext context) : base(context) { }
    }
}
