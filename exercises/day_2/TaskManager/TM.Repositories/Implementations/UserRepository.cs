using System.Data.Entity;
using TM.Data.Entities;

namespace TM.Repositories.Implementations
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context)
            : base(context) { }
    }
}
