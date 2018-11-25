using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Entities;

namespace TM.Repositories.Implementations
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context)
            : base(context) { }
    }
}
