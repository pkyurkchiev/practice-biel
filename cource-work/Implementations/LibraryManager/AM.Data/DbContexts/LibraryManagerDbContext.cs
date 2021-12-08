using LM.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Data.DbContexts
{
    public class LibraryManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Library> Library { get; set; }

        public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options)
        { }
    }
}
