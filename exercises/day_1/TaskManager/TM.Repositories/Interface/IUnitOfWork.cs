using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IUserRepository Users { get; set; }

        int SaveChanges();
    }
}
