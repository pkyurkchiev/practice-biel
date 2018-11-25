using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Entities;

namespace TM.Repositories.Implementations
{
    public abstract class Repository<T> where T : BaseEntity
    {
        #region Properties
        protected DbSet<T> DbSet { get; set; }
        protected DbContext Context { get; set; }
        #endregion

        #region Constructors
        public Repository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }
        #endregion

        #region Methods
        public virtual IEnumerable<T> GetAll(bool? isActive = null)
        {
            var query = this.DbSet.AsQueryable();

            return SoftDeleteQueryFilter(query, isActive);
        }

        public virtual T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;

            DbEntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            } else {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
                this.Delete(entity);
        }

        public virtual void Update(T entity, string excludeProperties = "")
        {
            DbEntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
            entry.Property("CreatedBy").IsModified = false;
            entry.Property("CreatedOn").IsModified = false;

            foreach (string excludeProperty in excludeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                entry.Property(excludeProperty).IsModified = false;
            }
        }
        #endregion

        #region private Methods
        private IQueryable<T> SoftDeleteQueryFilter(IQueryable<T> query, bool? isActivate)
        {
            if (isActivate.HasValue)
                query = query.Where(x => x.IsActive == isActivate.Value);

            return query;
        }
        #endregion
    }
}
