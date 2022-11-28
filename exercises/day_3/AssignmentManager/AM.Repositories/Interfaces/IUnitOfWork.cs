using Microsoft.EntityFrameworkCore;
using System;

namespace AM.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IAssignmentRepository Assignments { get; set; }
        IUserRepository Users { get; set; }
        int SaveChanges();
    }
}
