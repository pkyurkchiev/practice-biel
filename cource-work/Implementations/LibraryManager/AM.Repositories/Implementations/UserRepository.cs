using AM.Data.Entites;
using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AM.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
