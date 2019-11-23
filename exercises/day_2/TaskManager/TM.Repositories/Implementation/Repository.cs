using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Data.Entities;
using TM.Repositories.Interface;

namespace TM.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties
        protected DbSet<T> DbSet { get; set; }
        protected DbContext Context { get; set; }
        #endregion

        #region Constructors
        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            this.DbSet = this.Context.Set<T>();
        }
        #endregion

        #region Methods
        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet.AsEnumerable();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else
                this.DbSet.Add(entity);
        }

        public virtual void Update(T entity, string exludeProperties = "")
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;

            entry.State = EntityState.Modified;
            foreach (var exludePropertie in exludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                entry.Property(exludePropertie).IsModified = false;
            }
        }

        public virtual void Save(T entity)
        {
            if (entity.Id == 0)
                this.Insert(entity);
            else
                this.Update(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);
            if (entity != null)
                this.Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }
        #endregion
    }
}
