using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LM.Repositories.Implementations
{
    public class BookRepository : Repository<Library>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context) { }

        public override IEnumerable<Library> GetAll()
        {
            return this.Context.Set<Library>().Include("User").AsEnumerable();
        }
    }
}
