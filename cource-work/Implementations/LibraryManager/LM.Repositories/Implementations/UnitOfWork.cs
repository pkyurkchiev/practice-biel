using LM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context) 
        {
            _context = context;
            Library = new BookRepository(context);
            Users = new UserRepository(context);
        }

        public DbContext Context => _context;

        public IBookRepository Library { get; set; }
        public IUserRepository Users { get; set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                if (_context != null)
                    _context.Dispose();
        }
    }
}
