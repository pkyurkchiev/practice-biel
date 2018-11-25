using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Data.DBContexts;

namespace TM.Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly TaskManagerDbContext context = new TaskManagerDbContext();

        public UnitOfWork()
        {
            Users = new UserRepository(this.context);
        }

        public UserRepository Users { get; private set; }

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
    }
}
