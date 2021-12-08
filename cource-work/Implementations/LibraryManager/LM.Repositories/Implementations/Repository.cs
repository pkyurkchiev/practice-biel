using LM.Data.Entites;
using LM.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties
        public DbSet<T> DbSet { get; set; }
        public DbContext Context { get; set; }
        #endregion

        #region Constructors
        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            this.DbSet = this.Context.Set<T>();
        }
        #endregion

        #region public Methods
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

        public virtual void Update(T entity, string excludeProperties = "")
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;

            entry.State = EntityState.Modified;
            foreach (var item in excludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                entry.Property(item).IsModified = false;
            }
        }

        public virtual void Save(T entity)
        {
            if (entity.Id == 0)
                this.Insert(entity);
            else
                this.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
                this.DbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);
            if (entity != null)
                this.Delete(entity);
        }
        #endregion
    }
}
