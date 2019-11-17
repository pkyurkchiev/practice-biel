using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Repositories.Interface;

namespace TM.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            this._context = context;

            Users = new UserRepository(this._context);
        }

        public IUserRepository Users { get; set; }

        public DbContext Context
        {
            get => this._context;
        }

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            { 
                if (this._context != null)
                { 
                    this._context.Dispose();
                }
            }
        }
    }
}
