using System;
using TM.Data.DBContexts;

namespace TM.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private readonly TaskManagerDbContext context = new TaskManagerDbContext();
        #endregion

        #region Properties
        public UserRepository Users { get; private set; }
        public TaskRepository Tasks { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork()
        {
            Users = new UserRepository(this.context);
            Tasks = new TaskRepository(this.context);
        }
        #endregion
        
        #region Methods
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
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
