using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace TM.Repositories.Interfaces
{

    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IUserRepository Users { get; }

        ITaskRepository Tasks { get; }

        int SaveChanges();
    }
}
