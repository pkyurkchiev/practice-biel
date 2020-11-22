using AM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Assignments = new AssignmentRepository(context);
        }

        public IAssignmentRepository Assignments { get; set; }

        public DbContext Context
        {
            get => _context;
        }

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
