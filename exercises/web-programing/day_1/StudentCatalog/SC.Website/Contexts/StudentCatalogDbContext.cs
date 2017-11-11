using SC.Website.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SC.Website.Contexts
{
    public class StudentCatalogDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}