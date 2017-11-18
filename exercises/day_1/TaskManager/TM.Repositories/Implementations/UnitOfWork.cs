using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TM.Data.Context;
using TM.Repositories.Interfaces;

namespace TM.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly TaskManagerDbContext context = new TaskManagerDbContext();

        #endregion

        #region Constructors

        public UnitOfWork()
        {
            Users = new UserRepository(context);
            Tasks = new TaskRepository(context);
        }

        #endregion

        #region Methods

        public IUserRepository Users { get; private set; }

        public ITaskRepository Tasks { get; private set; }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }
        #endregion
    }
}
