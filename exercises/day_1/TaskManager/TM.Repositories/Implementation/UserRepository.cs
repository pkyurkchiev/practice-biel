using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Data.Entities;
using TM.Repositories.Interface;

namespace TM.Repositories.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context) { }
    }
}
