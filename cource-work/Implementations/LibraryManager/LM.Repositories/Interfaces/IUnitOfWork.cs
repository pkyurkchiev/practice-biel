using Microsoft.EntityFrameworkCore;
using System;

namespace LM.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IBookRepository Library { get; set; }
        IUserRepository Users { get; set; }
        int SaveChanges();
    }
}
