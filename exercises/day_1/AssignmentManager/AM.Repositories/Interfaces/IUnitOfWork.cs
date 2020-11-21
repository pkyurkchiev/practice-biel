using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IAssignmentRepository Assignments { get; set; }
        int SaveChanges();
    }
}
