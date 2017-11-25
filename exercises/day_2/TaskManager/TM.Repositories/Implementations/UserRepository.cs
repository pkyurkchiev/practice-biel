using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TM.Data.Entities;
using TM.Repositories.Interfaces;

namespace TM.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
