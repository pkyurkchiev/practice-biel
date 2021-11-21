using Microsoft.EntityFrameworkCore;
using System;

namespace AM.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IAssignmentRepository Assignments { get; set; }
        int SaveChanges();
    }
}
