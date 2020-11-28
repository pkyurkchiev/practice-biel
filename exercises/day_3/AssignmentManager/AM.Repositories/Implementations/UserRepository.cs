using AM.Data.Entities;
using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Repositories.Implementations
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    } 
}
