using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LM.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
